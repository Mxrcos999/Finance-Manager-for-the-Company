using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceManager.Infrastructure.Repository;

public class LancamentoRep : ILancamentoRep
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<Lancamento> _contaFinanceiras;
    private readonly DbSet<ApplicationUser> _user;
    private readonly DbSet<Categoria> _categorias;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string IdUsuarioLogado;
    private readonly UserManager<ApplicationUser> _userManager;

    public LancamentoRep(FinanceManagerContext context, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _contaFinanceiras = context.Set<Lancamento>();
        _user = context.Set<ApplicationUser>();
        _categorias = context.Set<Categoria>();
        _unitOfWork = unitOfWork;
        IdUsuarioLogado = _context._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        _userManager = userManager;
    }

    public async Task<IEnumerable<LancamentoResponse>> ObtemContaFinanceira(HistoricoQuery historicoQuery)
    {
        var contas = from Contas in _contaFinanceiras
                       .AsNoTracking()
                       .Include(i => i.Categorias)
                       .Include(i => i.Usuario)
                       .Where(historicoQuery.CreateFilterExpression(IdUsuarioLogado))
                     orderby Contas.Datalancamento descending
                     select new LancamentoResponse()
                     {
                         SaldoAtual = Contas.Usuario.Saldo,
                         Datalancamento = Contas.Datalancamento,
                         TipoLancamento = Contas.TipoLancamento.ToString(),
                         ValorLancamento = Contas.ValorLancamento,
                         Categoria = new CategoriaResponse()
                         {
                             Id = Contas.Categorias.Id,
                             Nome = Contas.Categorias.Nome,
                             Descricao = Contas.Categorias.Descricao,
                             TipoCategoria = Contas.Categorias.Tipo
                         }

                     };

        return contas.AsEnumerable();
    }

    public async Task<IEnumerable<LancamentoResponse>> IncluirContaFinanceiraAsync(Lancamento contaFinanceira)
    {
        try
        {
            var userLogado = await _userManager.FindByIdAsync(IdUsuarioLogado);

            contaFinanceira.UsuarioId = IdUsuarioLogado;

            var userAtualizado = await AtualizaSaldoUsuario(userLogado, contaFinanceira);

            _user.Update(userAtualizado);
            await _contaFinanceiras.AddAsync(contaFinanceira);
            var result = await _unitOfWork.CommitAsync();

            if (result)
                return await ObtemContaFinanceira(new HistoricoQuery(new DateTime(2023, 05, 01), new DateTime(2023, 05, 31)));

            return null;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    private async Task<ApplicationUser> AtualizaSaldoUsuario(ApplicationUser user, Lancamento contaFinanceira)
    {
        if (contaFinanceira.TipoLancamento == Lancamento.TiposLancamento.Credito)
        {
            user.Saldo += contaFinanceira.ValorLancamento;
            return user;
        }
        else
        {
            user.Saldo -= contaFinanceira.ValorLancamento;
            return user;
        }
    }
}

using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceManager.Infrastructure.Repository;

public class LancamentoRep : ILancamentoRep
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<Lancamento> _lancamentos;
    private readonly DbSet<ApplicationUser> _user;
    private readonly DbSet<Categoria> _categorias;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string IdUsuarioLogado;
    private readonly UserManager<ApplicationUser> _userManager;
    public ApplicationUser usuarioLogado;

    public LancamentoRep(FinanceManagerContext context, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _lancamentos = context.Set<Lancamento>();
        _user = context.Set<ApplicationUser>();
        _categorias = context.Set<Categoria>();
        _unitOfWork = unitOfWork;
        IdUsuarioLogado = _context._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        _userManager = userManager;
    }
    public async Task<ApplicationUser> ObterUserLogado()
    {
        usuarioLogado = await _userManager.FindByIdAsync(IdUsuarioLogado);
        return usuarioLogado;

    }
    public async Task<IEnumerable<LancamentoResponse>> ObterAsync(HistoricoQuery historicoQuery)
    {
        var contas = from Contas in _lancamentos
                       .AsNoTracking()
                       .Include(i => i.Categorias)
                       .Include(i => i.Usuario)
                       .Where(historicoQuery.CreateFilterExpression(IdUsuarioLogado))
                     orderby Contas.Datalancamento descending
                     select new LancamentoResponse()
                     {
                         Id = Contas.Id,
                         SaldoAtual = Contas.Usuario.Saldo,
                         Datalancamento = Contas.Datalancamento,
                         TipoLancamento = Contas.TipoLancamento,
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

    public async Task<Lancamento> ObterLancamentoByIdAsync(int id)
    {
        return await _lancamentos.FindAsync(id);
    }

    public async Task<IEnumerable<LancamentoResponse>> IncluirAsync(Lancamento lancamento)
    {
        try
        {
            var userLogado = await _userManager.FindByIdAsync(IdUsuarioLogado);

            lancamento.UsuarioId = IdUsuarioLogado;

            var userAtualizado = await AtualizaSaldoUsuario(userLogado, lancamento);

            _user.Update(userAtualizado);
            await _lancamentos.AddAsync(lancamento);
            var result = await _unitOfWork.CommitAsync();

            if (result)
                return await ObterAsync(new HistoricoQuery(new DateTime(2023, 05, 01), new DateTime(2023, 05, 31)));

            return null;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<LancamentoResponse>> AlterarAsync(Lancamento lancamento)
    {
        try
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                lancamento.UsuarioId = IdUsuarioLogado;

                var userAtualizado = await AtualizaSaldoUsuario(usuarioLogado, lancamento);

                _user.Update(userAtualizado);
                _lancamentos.Update(lancamento);

                await transaction.CommitAsync();

                var result = await _unitOfWork.CommitAsync();
                if (result)
                    return await ObterAsync(new HistoricoQuery(new DateTime(2023, 05, 01), new DateTime(2023, 05, 31)));
                return null;

            }
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }

    }

    public async Task DeletarLancamento(int idLancamento)
    {
        var lancamentoDeletar = await _lancamentos.FindAsync(idLancamento);
        var user = await ObterUserLogado();

        var userAtualizado = await AtualizaSaldoUsuario(user, lancamentoDeletar, true);
        _user.Update(userAtualizado);
        _lancamentos.Remove(lancamentoDeletar);
        await _unitOfWork.CommitAsync();

    }


    public async Task<ApplicationUser> AtualizaSaldoUsuario(ApplicationUser user, Lancamento lancamento, bool isUpdate = false)
    {
        if (isUpdate)
        {
            if (lancamento.TipoLancamento == Lancamento.TiposLancamento.Credito)
            {
                user.Saldo -= lancamento.ValorLancamento;
                return user;

            }
            else
            {
                user.Saldo += lancamento.ValorLancamento;
                return user;

            }
        }

        if (lancamento.TipoLancamento == Lancamento.TiposLancamento.Credito)
        {
            user.Saldo += lancamento.ValorLancamento;
            return user;
        }
        else
        {
            user.Saldo -= lancamento.ValorLancamento;
            return user;
        }
    }


}

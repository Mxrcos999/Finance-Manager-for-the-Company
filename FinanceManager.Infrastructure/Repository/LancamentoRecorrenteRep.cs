using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceManager.Infrastructure.Repository;

public class LancamentoRecorrenteRep : ILancamentoRecorrenteRep
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<LancamentoRecorrente> _lancamentoRecorrente;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string IdUsuarioLogado;

    public LancamentoRecorrenteRep(FinanceManagerContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _lancamentoRecorrente = context.Set<LancamentoRecorrente>();
        _unitOfWork = unitOfWork;
        IdUsuarioLogado = _context._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public async Task IncluirAsync(LancamentoRecorrente lancamento)
    {
        try
        {
            using (await _unitOfWork.BeginTransactionAsync())
            {
                lancamento.UsuarioId = IdUsuarioLogado;
                await _lancamentoRecorrente.AddAsync(lancamento);

                await _unitOfWork.CommitAsync();

                await _unitOfWork.CommitTransactionAsync();
            }
         
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<LancamentoRecorrenteResponse>> ObterLancamentosRecorrentesAsync(string idUsuario)
    {
        var lancamento =  (from lancamentosRecorrentes in _lancamentoRecorrente
                         .AsNoTracking()
                         .Include(i => i.Categoria)
                         .Where(wh => wh.UsuarioId == idUsuario)
                         select new LancamentoRecorrenteResponse()
                         {
                             DataPrevistaLancamento = lancamentosRecorrentes.DataPrevistaLancamento,
                             TituloLancamentoRecorrente = lancamentosRecorrentes.TituloLancamentoRecorrente,
                             TipoLancamento = lancamentosRecorrentes.TipoLancamento,
                             ValorLancamento = lancamentosRecorrentes.ValorLancamento,
                             Categoria = new CategoriaResponse()
                             {
                                 ColorCode = lancamentosRecorrentes.Categoria.ColorCode,
                                 Descricao = lancamentosRecorrentes.Categoria.Descricao,
                                 TipoCategoria = lancamentosRecorrentes.Categoria.Tipo,
                                 Id = lancamentosRecorrentes.Categoria.Id,
                                 Nome = lancamentosRecorrentes.Categoria.Nome,
                             }

                         }).AsEnumerable();

        return lancamento;
    }

    public async Task<IEnumerable<LancamentoRecorrenteResponse>> VerificaAgendamentoLancamentoAsync(string idUsuario)
    {
        var lancamentos = await ObterLancamentosRecorrentesAsync(idUsuario);

        if(!lancamentos.Any())
           return null;
        var lancamentosRecorrente = new List<LancamentoRecorrenteResponse>();

        foreach(var lancamentoAtual in lancamentos)
        {
            if (lancamentoAtual.DataPrevistaLancamento == DateTime.Now)
                lancamentosRecorrente.Add(lancamentoAtual);
        }

        return lancamentosRecorrente;

    }
}

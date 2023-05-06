using FinanceManager.Application.Interfaces;
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
            lancamento.UsuarioId = IdUsuarioLogado;
            await _lancamentoRecorrente.AddAsync(lancamento);
            
            await _unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}

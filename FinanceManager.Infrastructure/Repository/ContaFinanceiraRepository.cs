using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repository;

public class ContaFinanceiraRepository : IContaFinanceiraRepository
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<ContaFinanceira> _contaFinanceiras;

   
    public ContaFinanceiraRepository(FinanceManagerContext context)
    {
        _context = context;
        _contaFinanceiras = context.Set<ContaFinanceira>();
    }

    public async Task<IEnumerable<ContaFinanceiraResponse>> ObtemContaFinanceira()
    {
        var contas = from Contas in _contaFinanceiras
                       .AsNoTracking()
                     select new ContaFinanceiraResponse()
                     {
                         Entrada = Contas.Entradas,
                         Saida = Contas.Saidas,
                     };
        return contas.AsEnumerable();
    }
}

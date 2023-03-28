using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repository;

public class ContaFinanceiraRepository
{
    private readonly FinanceManagerContext _context;
    private readonly DbSet<ContaFinanceira> _contaFinanceiras;

    public ContaFinanceiraRepository(FinanceManagerContext context)
    {
        _context = context;
        _contaFinanceiras = context.Set<ContaFinanceira>();
    }

    public async Task ObtemContaFinanceira()
    {
        //será implementado 
    }
}

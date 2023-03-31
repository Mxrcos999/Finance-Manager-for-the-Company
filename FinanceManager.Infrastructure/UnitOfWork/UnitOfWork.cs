using FinanceManager.Application.Interfaces;
using FinanceManager.Infrastructure;

namespace FinanceManager.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly FinanceManagerContext _context;

    public UnitOfWork(FinanceManagerContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        var sucess = (await _context.SaveChangesAsync()) > 0;
        return sucess;
    }

    public void Dispose() =>
   _context.Dispose();

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}

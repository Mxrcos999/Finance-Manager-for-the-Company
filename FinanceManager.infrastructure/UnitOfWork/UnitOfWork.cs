using FinanceManager.Application.Interfaces;

namespace FinanceManager.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly FinanceManagerContext _context;

    public UnitOfWork(FinanceManagerContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        var sucess = (await _context.SaveChangesAsync()) > 0;
        return sucess;
    }

    public void Dispose() =>
   _context.Dispose();

    public Task RollbackAsync()
    {
        return Task.CompletedTask;
    }
}

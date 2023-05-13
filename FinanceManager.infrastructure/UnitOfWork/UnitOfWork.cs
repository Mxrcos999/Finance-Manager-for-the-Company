using FinanceManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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

    public async Task OpenConnectionAsync()
    {
        await _context.Database.GetDbConnection().OpenAsync();
    }

    public async Task CloseConnectionAsync()
    {
        await _context.Database.GetDbConnection().CloseAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }


    public void Dispose() =>
   _context.Dispose();

    public Task RollbackAsync()
    {
        return Task.CompletedTask;
    }
}

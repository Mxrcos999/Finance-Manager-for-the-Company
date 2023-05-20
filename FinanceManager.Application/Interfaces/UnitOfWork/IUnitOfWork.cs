using Microsoft.EntityFrameworkCore.Storage;

namespace FinanceManager.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync();
    Task RollbackAsync();
    Task<bool> CommitTransactionAsync();
    Task OpenConnectionAsync();
    Task CloseConnectionAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task RollbackTransactionAsync();
}

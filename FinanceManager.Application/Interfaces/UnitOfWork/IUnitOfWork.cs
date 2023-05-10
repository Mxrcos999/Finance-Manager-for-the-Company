namespace FinanceManager.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync();
    Task RollbackAsync();
    Task OpenConnectionAsync();
    Task CloseConnectionAsync();
    Task BeginTransactionAsync();
    Task RollbackTransactionAsync();
}

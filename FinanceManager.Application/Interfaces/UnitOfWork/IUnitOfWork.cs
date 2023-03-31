namespace FinanceManager.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
    Task Rollback();
}

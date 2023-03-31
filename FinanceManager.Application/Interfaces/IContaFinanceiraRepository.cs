using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraRepository
{
    Task<IEnumerable<ContaFinanceiraResponse>> ObtemContaFinanceira();
}

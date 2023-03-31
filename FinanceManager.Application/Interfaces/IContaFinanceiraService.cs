using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraService
{
    Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras();
}

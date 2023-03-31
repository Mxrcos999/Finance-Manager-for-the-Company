using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain;

namespace FinanceManager.Application.Services;

public class ContaFinanceiraService : IContaFinanceiraService
{
    private readonly IContaFinanceiraRepository _contaFinanceiraRepository;

    public ContaFinanceiraService(IContaFinanceiraRepository contaFinanceiraRepository)
    {
        _contaFinanceiraRepository = contaFinanceiraRepository;
    }

    public async Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras()
    {
        return await _contaFinanceiraRepository.ObtemContaFinanceira();
    }
}

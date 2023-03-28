using FinanceManager.Infrastructure.Repository;

namespace FinanceManager.Application.Services;

public class ContaFinanceiraService
{
    private readonly ContaFinanceiraRepository _contaFinanceiraRepository;

    public ContaFinanceiraService(ContaFinanceiraRepository contaFinanceiraRepository)
    {
        _contaFinanceiraRepository = contaFinanceiraRepository;
    }

    public async Task ObterContasFinanceiras()
    {
        //será implementado
    }
}

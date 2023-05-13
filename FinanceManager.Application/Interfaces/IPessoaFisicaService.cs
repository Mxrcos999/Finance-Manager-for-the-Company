using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Application.Interfaces;

public interface IPessoaFisicaService
{
    Task<PessoaFisicaResponse> ObterAsync();
}

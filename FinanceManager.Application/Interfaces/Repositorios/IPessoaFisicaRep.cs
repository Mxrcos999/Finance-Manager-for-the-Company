using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Application.Interfaces.Repositorios;

public interface IPessoaFisicaRep
{
    Task<PessoaFisicaResponse> ObterAsync();
}

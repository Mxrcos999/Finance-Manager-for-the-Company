using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Application.Interfaces.Repositorios;

public interface IPessoaJuridicaRep
{
    Task<PessoaJuridicaResponse> ObterAsync();

}

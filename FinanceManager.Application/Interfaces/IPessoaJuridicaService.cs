using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Application.Interfaces;

public interface IPessoaJuridicaService
{
    Task<PessoaJuridicaResponse> Obtersync();

}

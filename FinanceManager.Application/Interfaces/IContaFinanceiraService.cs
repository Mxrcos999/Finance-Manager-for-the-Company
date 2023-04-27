using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraService
{
    Task IncluirContaFinanceira(ContaFinanceiraCadastroRequest contaFinanceira, string idConta);
    Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras(string idUser);
}

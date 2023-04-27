using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraService
{
    Task IncluirContaFinanceira(ContaFinanceiraCadastroRequest contaFinanceira, ApplicationUser user);
        Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras(string idUser);
}

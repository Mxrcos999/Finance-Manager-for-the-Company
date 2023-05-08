using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraService
{
    Task<IEnumerable<ContaFinanceiraResponse>> IncluirContaFinanceira(ContaFinanceiraCadastroRequest contaFinanceira);
    Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras(HistoricoQuery historicoQuery);
}

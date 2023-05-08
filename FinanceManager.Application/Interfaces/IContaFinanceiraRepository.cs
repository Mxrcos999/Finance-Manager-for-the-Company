using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface IContaFinanceiraRepository
{
    Task<IEnumerable<ContaFinanceiraResponse>> ObtemContaFinanceira(HistoricoQuery historicoQuery);
    Task<IEnumerable<ContaFinanceiraResponse>> IncluirContaFinanceiraAsync(ContaFinanceira contaFinanceira);

}

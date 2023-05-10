using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface ILancamentoRep
{
    Task<IEnumerable<LancamentoResponse>> ObtemContaFinanceira(HistoricoQuery historicoQuery);
    Task<IEnumerable<LancamentoResponse>> IncluirContaFinanceiraAsync(Lancamento contaFinanceira);

}

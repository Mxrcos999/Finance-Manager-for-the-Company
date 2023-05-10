using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface ILancamentoService
{
    Task<IEnumerable<LancamentoResponse>> IncluirContaFinanceira(LancamentoCadastroRequest contaFinanceira);
    Task<IEnumerable<LancamentoResponse>> ObterContasFinanceiras(HistoricoQuery historicoQuery);
}

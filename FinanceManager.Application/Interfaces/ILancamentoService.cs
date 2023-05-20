using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.DTOs.DtosUpdate;

namespace FinanceManager.Application.Interfaces;

public interface ILancamentoService
{
    Task<IEnumerable<LancamentoResponse>> IncluirAsync(LancamentoCadastroRequest lancamento);
    Task<IEnumerable<LancamentoResponse>> AlterarAsync(LancamentoUpdateRequest lancamento);
    Task<IEnumerable<LancamentoResponse>> DeletarAsync(int[] ids);
    Task<IEnumerable<LancamentoResponse>> ObterAsync(HistoricoQuery historicoQuery);
}

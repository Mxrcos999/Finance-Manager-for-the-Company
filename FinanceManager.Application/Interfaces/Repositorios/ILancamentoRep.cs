using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces.Repositorios;

public interface ILancamentoRep
{
    Task<IEnumerable<LancamentoResponse>> ObterAsync(HistoricoQuery historicoQuery);
    Task<IEnumerable<LancamentoResponse>> IncluirAsync(Lancamento lancamento);

    Task<ApplicationUser> AtualizaSaldoUsuario(ApplicationUser user, Lancamento lancamento, bool isUpdate = false);
    Task<IEnumerable<LancamentoResponse>> AlterarAsync(Lancamento lancamento);
    Task<ApplicationUser> ObterUserLogado();
    Task DeletarLancamento(int idLancamento);
    Task<Lancamento> ObterLancamentoByIdAsync(int id);

}

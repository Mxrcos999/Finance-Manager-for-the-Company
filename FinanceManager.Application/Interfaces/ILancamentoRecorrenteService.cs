using FinanceManager.Application.DTOs.DtosCadastro;

namespace FinanceManager.Application.Interfaces;

public interface ILancamentoRecorrenteService
{
    Task IncluirASync(LancamentoRecorrenteCadastroRequest lancamento);
}

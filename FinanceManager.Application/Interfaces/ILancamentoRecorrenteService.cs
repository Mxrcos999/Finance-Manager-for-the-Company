using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Application.Interfaces;

public interface ILancamentoRecorrenteService
{
    Task IncluirASync(LancamentoRecorrenteCadastroRequest lancamentoRecorrente);
    Task<OlimpusResponseDefault> VerificaAgendamentoLancamento(string idUsuario);
}

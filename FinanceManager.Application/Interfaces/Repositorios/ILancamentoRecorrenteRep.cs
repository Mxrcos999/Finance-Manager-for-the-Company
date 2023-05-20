using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces.Repositorios;

public interface ILancamentoRecorrenteRep
{
    Task IncluirAsync(LancamentoRecorrente lancamento);
    Task<IEnumerable<LancamentoRecorrenteResponse>> VerificaAgendamentoLancamentoAsync(string idUsuario);
}
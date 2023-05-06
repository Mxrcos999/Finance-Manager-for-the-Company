using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface ILancamentoRecorrenteRep
{
    Task IncluirAsync(LancamentoRecorrente lancamento);
}

using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces.Repositorios;

public interface ILancamentoRecorrenteRep
{
    Task IncluirAsync(LancamentoRecorrente lancamento);
}

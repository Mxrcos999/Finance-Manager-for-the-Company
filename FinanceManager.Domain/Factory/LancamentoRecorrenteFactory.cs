using FinanceManager.Domain.Entidades;
using static FinanceManager.Domain.Entidades.ContaFinanceira;

namespace FinanceManager.Domain.Factory;

public static class LancamentoRecorrenteFactory
{
    public static LancamentoRecorrente Create(decimal valorLancamento, DateTime dataPrevistaLancamentoRecorrente,
        TiposLancamento tipoLancamento, Categoria categoria)
    {
        return new LancamentoRecorrente
            (valorLancamento,
            dataPrevistaLancamentoRecorrente,
            tipoLancamento,
            categoria);
    }
}

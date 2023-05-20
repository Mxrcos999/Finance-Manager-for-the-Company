using FinanceManager.Domain.Entidades;
using static FinanceManager.Domain.Entidades.Lancamento;

namespace FinanceManager.Domain.Factory;

public static class LancamentoRecorrenteFactory
{
    public static LancamentoRecorrente Create(decimal valorLancamento, string tituloLancamento, DateTime dataPrevistaLancamentoRecorrente,
        TiposLancamento tipoLancamento, Categoria categoria)
    {
        return new LancamentoRecorrente
            (valorLancamento,
            tituloLancamento,
            dataPrevistaLancamentoRecorrente,
            tipoLancamento,
            categoria);
    }
}

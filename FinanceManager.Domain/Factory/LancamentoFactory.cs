using FinanceManager.Domain.Entidades;
using static FinanceManager.Domain.Entidades.Lancamento;

namespace FinanceManager.Domain.Factory;

public static class LancamentoFactory
{
    public static Lancamento Create(decimal valorLancamento, TiposLancamento tipoLancamento, Categoria categoria, string tituloLancamento, DateTime dataLancamento)
    {
        return new Lancamento
              (valorLancamento,
              tipoLancamento,
              categoria,
              tituloLancamento,
              dataLancamento
              );
    }
}

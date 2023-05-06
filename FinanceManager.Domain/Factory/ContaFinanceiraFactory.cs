using FinanceManager.Domain.Entidades;
using static FinanceManager.Domain.Entidades.ContaFinanceira;

namespace FinanceManager.Domain.Factory;

public static class ContaFinanceiraFactory
{
    public static ContaFinanceira Create(decimal valorLancamento, TiposLancamento tipoLancamento, Categoria? categoria = null)
    {
        return new ContaFinanceira
              (valorLancamento,
              tipoLancamento,
              categoria
              );
    }
}

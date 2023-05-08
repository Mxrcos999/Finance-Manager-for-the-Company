using FinanceManager.Domain.Entidades;
using LinqKit;
using System.Linq.Expressions;

namespace FinanceManager.Application.DTOs.DtoQuery;

public sealed class HistoricoQuery
{
    public HistoricoQuery(DateTime dataHoraInicial, DateTime dataHoraFinal)
    {
        DataHoraInicial = dataHoraInicial;

        DataHoraFinal = dataHoraFinal;

    }
    public DateTime DataHoraInicial { get; set; }
    public DateTime DataHoraFinal{ get; set; }

    public Expression<Func<ContaFinanceira, bool>> CreateFilterExpression()
    {
        var predicate = PredicateBuilder.True<ContaFinanceira>()
            .And(p => p.Datalancamento >= DataHoraInicial)
            .And(p => p.Datalancamento <= DataHoraFinal);

        return predicate;
    }
}

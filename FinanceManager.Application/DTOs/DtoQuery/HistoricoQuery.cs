using FinanceManager.Domain.Entidades;
using LinqKit;
using System.Linq.Expressions;

namespace FinanceManager.Application.DTOs.DtoQuery;

public sealed class HistoricoQuery
{
    public HistoricoQuery(DateTime? dataHoraInicial, DateTime? dataHoraFinal)
    {
        DataHoraInicial = dataHoraInicial;

        DataHoraFinal = dataHoraFinal;

    }
    public string? UsuarioId { get; set; }
    public DateTime? DataHoraInicial { get; set; }
    public DateTime? DataHoraFinal{ get; set; }

    public Expression<Func<Lancamento, bool>> CreateFilterExpression(string? idUsuario = null)
    {
        if (DataHoraInicial is null && DataHoraFinal is null)
        {
            var user = PredicateBuilder.True<Lancamento>()
                .And(p => p.UsuarioId == idUsuario);
                    
            return user;

        }


        var predicate = PredicateBuilder.True<Lancamento>()
             .And(p => p.UsuarioId == idUsuario)
            .And(p => p.Datalancamento >= DataHoraInicial)
            .And(p => p.Datalancamento <= DataHoraFinal);

        return predicate;
    }
}

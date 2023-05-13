using FinanceManager.Domain.Entidades;
using LinqKit;
using System.Linq.Expressions;

namespace FinanceManager.Application.DTOs.DtoQuery;

public sealed class HistoricoQuery
{
    public HistoricoQuery(DateTime? dataHoraInicial = null, DateTime? dataHoraFinal = null, int? id = null)
    {
        DataHoraInicial = dataHoraInicial;
        Id = id;
        DataHoraFinal = dataHoraFinal;

    }
    public DateTime? DataHoraInicial { get; set; }
    public DateTime? DataHoraFinal { get; set; }
    public int? Id { get; set; }

    public Expression<Func<Lancamento, bool>> CreateFilterExpression(string? idUsuario = null)
    {

        var predicate = PredicateBuilder.True<Lancamento>()
            .And(p => p.UsuarioId == idUsuario);



        if (DataHoraFinal.HasValue)
        {
            predicate = predicate.And(p => p.Datalancamento >= DataHoraInicial.Value);
        }

        if (DataHoraFinal.HasValue)
        {
            predicate = predicate.And(p => p.Datalancamento <= DataHoraFinal.Value);
        }  
        
        if (Id is not null)
        {
            predicate = predicate.And(p => p.Id == Id);
        }
     

        return predicate;
    }
}

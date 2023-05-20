using FinanceManager.Domain.Entidades;
using static FinanceManager.Domain.Entidades.Lancamento;

namespace FinanceManager.Application.DTOs.DtosResponse;

public sealed class LancamentoRecorrenteResponse
{
    public string TituloLancamentoRecorrente { get; set; }
    public decimal ValorLancamento { get; set; }
    public DateTime DataPrevistaLancamento { get;  set; }
    public TiposLancamento TipoLancamento { get;  set; }
    public CategoriaResponse Categoria { get; set; }
}

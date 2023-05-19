using static FinanceManager.Domain.Entidades.Lancamento;

namespace FinanceManager.Application.DTOs.DtosResponse;

public class LancamentoResponse
{
    public int Id { get; set; }
    public string TituloLancamento { get; set; }
    public decimal? SaldoAtual { get; set; }
    public decimal ValorLancamento { get; set; }
    public TiposLancamento TipoLancamento { get; set; }
    public DateTime Datalancamento { get; set; }
    public CategoriaResponse Categoria { get; set; }
}

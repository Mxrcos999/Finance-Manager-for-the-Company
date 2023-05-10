namespace FinanceManager.Application.DTOs.DtosResponse;

public class LancamentoResponse
{
    public string TituloLancamento { get; set; }
    public decimal? SaldoAtual { get; set; }
    public decimal ValorLancamento { get; set; }
    public string TipoLancamento { get; set; }
    public DateTime Datalancamento { get; set; }
    public CategoriaResponse Categoria { get; set; }
}

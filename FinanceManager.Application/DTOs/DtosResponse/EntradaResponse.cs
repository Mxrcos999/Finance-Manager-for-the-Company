namespace FinanceManager.Application.DTOs.DtosResponse;

public sealed class EntradaResponse
{
    public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public CategoriaResponse Categoria { get; set; }
}

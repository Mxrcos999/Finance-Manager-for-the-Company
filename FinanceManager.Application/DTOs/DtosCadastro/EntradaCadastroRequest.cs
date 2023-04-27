using FinanceManager.Domain.Entidades;
using static FinanceManager.Domain.Entidades.ContaFinanceira;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class EntradaCadastroRequest
{
    public decimal? SaldoAtual { get; private set; }
    public decimal? ValorLancamento { get; private set; }
    public TiposLancamento TipoLancamento { get; private set; }
    public DateTime Datalancamento { get; private set; }
    public Categoria Categoria { get; set; }
}

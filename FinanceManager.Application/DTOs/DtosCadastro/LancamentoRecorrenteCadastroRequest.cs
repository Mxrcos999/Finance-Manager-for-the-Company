using static FinanceManager.Domain.Entidades.Lancamento;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class LancamentoRecorrenteCadastroRequest
{
    public decimal ValorLancamento { get; set; }
    public string TituloLancamento { get; set; }
    public DateTime DataPrevistaLancamento { get; set; }
    public TiposLancamento TipoLancamento { get; set; }
    public int CategoriaId { get; set; }
    public bool Verificado { get; set; }
}

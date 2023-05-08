using FinanceManager.Domain.Utils;
using static FinanceManager.Domain.Entidades.ContaFinanceira;

namespace FinanceManager.Domain.Entidades;

public class LancamentoRecorrente : EntidadeBase
{
    public decimal ValorLancamento { get; private set; }
    public DateTime DataPrevistaLancamento { get; private set; }
    public TiposLancamento TipoLancamento { get; private set; }
    public string UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; private set; }
    //Constructor para ef core
    public LancamentoRecorrente() {}
    public LancamentoRecorrente(decimal valorLancamento, DateTime dataPrevistaLancamentoRecorrente, 
        TiposLancamento tipoLancamento, Categoria categoria)
    {
        ValorLancamento = valorLancamento;
        DataPrevistaLancamento = dataPrevistaLancamentoRecorrente;
        TipoLancamento = tipoLancamento;
        Categoria = categoria;
        DataHoraCadastro = DateTime.Now.ToUniversalTime();
    }

}

using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Lancamento : EntidadeBase
{
    public string TituloLancamento { get; private set; }
    public decimal ValorLancamento { get; private set; }
    public TiposLancamento TipoLancamento { get; private set; }
    public DateTime Datalancamento { get; private set; }
    public string UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }
    public int? CategoriaId { get; set; }
    public Categoria? Categorias { get; set; }

    public Lancamento() { }
    public Lancamento(decimal valorLancamento, TiposLancamento tipoLancamento, Categoria categoria, string tituloLancamento)
    {

        ValorLancamento = valorLancamento;
        TipoLancamento = tipoLancamento;
        Datalancamento = DateTime.Now.ToUniversalTime();
        Categorias = categoria;
        DataHoraCadastro = DateTime.Now.ToUniversalTime();
        TituloLancamento = tituloLancamento;
    }
    public enum TiposLancamento
    {
        Credito,
        Debito
    }

}
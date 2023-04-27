using FinanceManager.Domain.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace FinanceManager.Domain.Entidades;

public class ContaFinanceira : EntidadeBase
{
    public decimal? SaldoAtual { get; private set; }
    public decimal ValorLancamento { get; private set; }
    public TiposLancamento TipoLancamento { get; private set; }
    public DateTime Datalancamento { get; private set; }
    public string UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }  
    public int CategoriaId { get; set; }

    public Categoria Categorias { get;  set; }

    public ContaFinanceira() {}
    public ContaFinanceira(decimal saldoAtual, decimal valorLancamento, TiposLancamento tipoLancamento, Categoria categoria)
    {
        ValorLancamento = valorLancamento;
        TipoLancamento = tipoLancamento;
        Datalancamento = DateTime.Now;
        Categorias = categoria;
    }
    public enum TiposLancamento
    {
        Credito,
        Debito
    }

}
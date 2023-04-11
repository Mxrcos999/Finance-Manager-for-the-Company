using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Entrada : EntidadeBase
{
    public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public Categoria Categorias { get; set; }
    public Entrada(decimal valor, DateTime dataEntrada, Categoria categorias)
    {
        Valor = valor;
        DataEntrada = dataEntrada;
        Categorias = categorias;
    }
    public Entrada() { }
}
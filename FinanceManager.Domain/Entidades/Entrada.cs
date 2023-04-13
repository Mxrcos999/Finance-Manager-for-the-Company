using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Entrada : EntidadeBase
{
    public decimal Valor { get; private set; }
    public DateTime DataEntrada { get; private set; }
    public Categoria Categorias { get; private set; }
    public Entrada(decimal valor, DateTime dataEntrada, Categoria categorias)
    {
        Valor = valor;
        DataEntrada = dataEntrada;
        Categorias = categorias;
    }
    public Entrada() { }
}
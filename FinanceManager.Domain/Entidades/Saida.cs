using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Saida : EntidadeBase
{
    public decimal Valor { get;private set; }
    public DateTime DataSaida { get;private set; }
    public Categoria Categorias { get;private set; }
    public Saida(decimal valor, DateTime dataSaida, Categoria categorias)
    {
        Valor = valor;
        DataSaida = dataSaida;
        Categorias = categorias;
    }
    public Saida()
    {

    }
}
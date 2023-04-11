using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Saida : EntidadeBase
{
    public decimal Valor { get; set; }
    public DateTime DataSaida { get; set; }
    public Categoria Categorias { get; set; }
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
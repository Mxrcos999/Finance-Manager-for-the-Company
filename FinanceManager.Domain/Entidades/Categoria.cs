using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Categoria : EntidadeBase
{
    public Categoria()
    {

    }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    //0 - entrada|1-saida
    public char Tipo { get; set; }
}
using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain;

public class Categoria : EntidadeBase
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    //0 - entrada|1-saida
    public char Tipo { get; set; }
}
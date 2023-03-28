using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain;

public class Entrada : EntidadeBase
{
    public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
    public Categoria Categorias { get; set; }
}
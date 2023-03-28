using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain;

public class Saida : EntidadeBase
{
    public decimal Valor { get; set; }
    public DateTime DataSaida { get; set; }
    public Categoria Categorias { get; set; }
}
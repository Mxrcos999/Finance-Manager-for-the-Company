using FinanceManager.Domain.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Domain;

public class ContaFinanceira : EntidadeBase
{
    [NotMapped]
    public decimal Saldo { get; set; }
    public Entrada Entradas { get; set; }
    public Saida Saidas { get; set; }
}

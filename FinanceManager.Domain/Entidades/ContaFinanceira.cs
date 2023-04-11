using FinanceManager.Domain.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Domain.Entidades;

public class ContaFinanceira : EntidadeBase
{
    [NotMapped]
    public decimal Saldo { get; set; }
    public List<Entrada> Entradas { get; set; }
    public List<Saida> Saidas { get; set; }
    public ContaFinanceira() {}
    public ContaFinanceira(List<Entrada> entrada, List<Saida> saida, decimal saldo)
    {
        Saldo = saldo;
        Entradas = entrada;
        Saidas = saida;
    }
}

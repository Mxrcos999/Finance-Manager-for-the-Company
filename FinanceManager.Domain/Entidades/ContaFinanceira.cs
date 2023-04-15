using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class ContaFinanceira : EntidadeBase
{
    public decimal Saldo { get; private set; }
    public List<Entrada>? Entradas { get; private set; }
    public List<Saida>? Saidas { get; private set; }
    public ContaFinanceira() {}
    public ContaFinanceira(List<Entrada> entrada, List<Saida> saida, decimal saldo)
    {
        Saldo = saldo;
        Entradas = entrada;
        Saidas = saida;
    }
}
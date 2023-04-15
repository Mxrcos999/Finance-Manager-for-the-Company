using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class Empregador : EntidadeBase
{
    public decimal ValorPago { get; private set; }
    public string RazaoSocial { get; private set; }
    public string Cnpj { get; private set; }
    public bool EmpresaAtual { get; private set; }

    public Empregador()  { }

    public Empregador(string razaoSocial, string cnpj, bool empresaAtual, decimal valorPago)
    {
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        EmpresaAtual = empresaAtual;
        ValorPago = valorPago;
    }
}

using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class PessoaJuridica : EntidadeBase
{
    public string? RazaoSocial { get; private set; }
    public string? Cnpj { get; private set; }
    public decimal? FaturamentoMensal { get; private set; }
    public decimal? FaturamentoAnual { get; private set; }

    public PessoaJuridica(string? razaoSocial, string? cnpj, decimal? faturamentoMensal, decimal? faturamentoAnual)
    {
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        FaturamentoMensal = faturamentoMensal;
        FaturamentoAnual = faturamentoAnual;
    }
    public PessoaJuridica()
    {
        
    }
}

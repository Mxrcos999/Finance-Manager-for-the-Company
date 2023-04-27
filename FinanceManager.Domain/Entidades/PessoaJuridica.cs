namespace FinanceManager.Domain.Entidades;

public class PessoaJuridica : Pessoa
{
    public string? RazaoSocial { get; private set; }
    public string? Cnpj { get; private set; }
    public decimal? FaturamentoMensal { get; private set; }
    public decimal? FaturamentoAnual { get; private set; }

    public PessoaJuridica(string? razaoSocial, string? cnpj, decimal? faturamentoMensal,
        decimal? faturamentoAnual, ICollection<Endereco> enderecos, ICollection<Telefone> telefones, string[] emails)
        : base(enderecos, telefones, emails)
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

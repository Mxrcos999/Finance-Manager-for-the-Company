namespace FinanceManager.Domain.Entidades;

public class PessoaFisica : Pessoa
{
    public ApplicationUser User { get; set; }
    public string Cpf { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public ContaFinanceira? ContaFinanceira { get; set; }
    public ICollection<Empregador> Empregador { get; private set; }

    public PessoaFisica(string cpf, string nome, DateTime dataNascimento, ICollection<Empregador> empregador, 
        List<Endereco> enderecos, List<Telefone> telefones, List<string> emails) 
        : base(enderecos, telefones, emails)
    {
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Empregador = empregador;
        Nome = nome;
    }
    public PessoaFisica()
    {

    }
}

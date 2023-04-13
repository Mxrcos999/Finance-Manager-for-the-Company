using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class PessoaFisica : EntidadeBase
{
    public string Cpf { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public ICollection<Empregador> Empregador { get; private set; }

    public PessoaFisica(string cpf,string nome, DateTime dataNascimento, ICollection<Empregador> empregador) 
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

using FinanceManager.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.Entidades;

public class PessoaFisica : Pessoa
{
    public ApplicationUser User { get; set; }
    public Cpf Cpf { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public ICollection<Empregador> Empregador { get; private set; }

    public PessoaFisica(Cpf cpf, string nome, DateTime dataNascimento, ICollection<Empregador> empregador,
        ICollection<Endereco> enderecos, ICollection<Telefone> telefones, string[] emails) 
        : base(enderecos, telefones, emails)
    {
        if (!cpf.Isvalid) throw new ValidationException("Cpf informado não é valido!");
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Empregador = empregador;
        Nome = nome;
    }
    public PessoaFisica() { }
  
}

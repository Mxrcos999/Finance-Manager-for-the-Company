using FinanceManager.Domain.Utils;

namespace FinanceManager.Domain.Entidades;

public class PessoaFisica : EntidadeBase
{
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public ICollection<Empregador> Empregador { get; set; }

}

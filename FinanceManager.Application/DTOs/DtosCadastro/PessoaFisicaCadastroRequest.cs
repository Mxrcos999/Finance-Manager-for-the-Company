using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public class PessoaFisicaCadastroRequest
{
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public ICollection<Empregador> Empregador { get; set; }
}

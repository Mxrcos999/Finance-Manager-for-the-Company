using FinanceManager.Domain;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public class UsuarioPessoaFisicaCadastroRequest
{
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public ICollection<EmpregadorCadastroRequest> Empregador { get; set; }
    public PessoaCadastroRequest Pessoa { get; set; }
}

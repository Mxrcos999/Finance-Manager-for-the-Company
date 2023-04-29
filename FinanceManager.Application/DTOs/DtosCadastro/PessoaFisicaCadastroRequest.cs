using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public class PessoaFisicaCadastroRequest : PessoaCadastroRequest
{
    [Required(ErrorMessage = "O campo CPF é obrigatório")]
    public string Cpf { get; set; }
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
    public DateTime DataNascimento { get; set; }
    public ICollection<EmpregadorCadastroRequest> Empregador { get; set; }
}

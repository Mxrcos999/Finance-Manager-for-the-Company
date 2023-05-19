using FinanceManager.Domain.Entidades;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class PessoaJuridicaCadastroRequest : PessoaCadastroRequest
{
    [Required(ErrorMessage = "O campo razão social é obrigatório")]
    [MaxLength(60, ErrorMessage = "A razão social não deve ser superior a 60 caracteres.")]
    [MinLength(5, ErrorMessage = "A razão social não deve ser inferior a 5 caracteres.")]
    public string RazaoSocial { get; set; }
    [Required(ErrorMessage = "O campo CNPJ é obrigatório")]
    public string Cnpj { get; set; }
    public ICollection<TelefoneCadastroRequest> Telefone { get; set; }
    public DateTime DataAberturaEmpresa { get; set; }

}

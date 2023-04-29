using System.ComponentModel.DataAnnotations;
using static FinanceManager.Domain.Entidades.Endereco;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class EnderecoCadastroRequest
{
    [Required(ErrorMessage = "O campo número deve ser informado.")]
    [MaxLength(8, ErrorMessage = "O número não deve ser superior a 6 caracteres.")]
    public string Numero { get; set; }

    [Required(ErrorMessage = "O campo logradouro deve ser informado.")]
    [MaxLength(60, ErrorMessage = "O logradouro não deve ser superior a 60 caracteres.")]
    [MinLength(5, ErrorMessage = "O logradouro não deve ser inferior a 5 caracteres.")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo cep deve ser informado.")]
    [StringLength(8)]
    public string Cep { get; set; }
    [Required(ErrorMessage = "O campo UF deve ser informado.")]
    [StringLength(2)]
    public string Uf { get; set; }
    public TiposLogradouro TipoLogradouro { get; set; }

}

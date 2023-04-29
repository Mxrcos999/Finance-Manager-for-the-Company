using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class EmpregadorCadastroRequest
{
    [Required(ErrorMessage = "O campo salário liquido é obrigatório")]
    public decimal ValorPago { get; set; }

    [Required(ErrorMessage = "O campo razão social é obrigatório")]
    [MaxLength(60, ErrorMessage = "A razão social não deve ser superior a 60 caracteres.")]
    [MinLength(5, ErrorMessage = "A razão social não deve ser inferior a 5 caracteres.")]
    public string RazaoSocial { get; set; }
    [Required(ErrorMessage = "O campo CNPJ é obrigatório")]
    public string Cnpj { get; set; }
    public bool EmpresaAtual { get; set; }
}

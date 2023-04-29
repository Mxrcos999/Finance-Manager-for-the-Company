using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class TelefoneCadastroRequest
{
    [Required(ErrorMessage = "O campo DDD deve ser informado.")]
    [MaxLength(3, ErrorMessage = "O campo DDI deve conter até 3 caracteres")]

    public string Ddd { get; set; }
    [Required(ErrorMessage = "O campo DDI deve ser informado.")]
    [StringLength(3, ErrorMessage = "O campo DDI deve conter 3 caracteres")]
    public string Ddi { get; set; }
    [Required(ErrorMessage = "O campo número de telefone deve ser informado.")]
    [StringLength(10, ErrorMessage = "O campo número de telefone deve conter 10 caracteres")]
    public string Numero { get; set; }
    public bool Principal { get; set; }
    [Required(ErrorMessage = "O campo tipo de telefone deve ser informado.")]
    public string TipoTelefone { get; set; }

}

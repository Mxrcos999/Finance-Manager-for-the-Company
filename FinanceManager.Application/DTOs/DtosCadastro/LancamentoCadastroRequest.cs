using System.ComponentModel.DataAnnotations;
using static FinanceManager.Domain.Entidades.Lancamento;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class LancamentoCadastroRequest
{
    [Required(ErrorMessage = "O titulo do lançamento deve ser informado")]
    public string TituloLancamento { get; set; }   
    public DateTime DataLancamento { get; set; }
    
    [Range(1, Double.PositiveInfinity, ErrorMessage = "O valor de lançamento deve ser maior que 0")]
    public decimal ValorLancamento { get; set; }
    [Required(ErrorMessage = "O tipo de lançamento deve ser informado! (Crédito | Débito)")]
    public TiposLancamento TipoLancamento { get; set; }
    [Required(ErrorMessage = "A categoria deve ser informada!")]
    public int? CategoriaId { get; set; }
}

using System.ComponentModel.DataAnnotations;
using static FinanceManager.Domain.Entidades.ContaFinanceira;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class ContaFinanceiraCadastroRequest
{
    [Range(1, Double.PositiveInfinity, ErrorMessage = "O valor de lançamento deve ser maior que 0")]
    public decimal ValorLancamento { get; set; }
    [Required(ErrorMessage = "O tipo de lançamento deve ser informado! (Crédito | Débito)")]
    public TiposLancamento TipoLancamento { get; set; }
    [Required(ErrorMessage = "A categoria deve ser informada!")]
    public int? CategoriaId { get; set; }
}

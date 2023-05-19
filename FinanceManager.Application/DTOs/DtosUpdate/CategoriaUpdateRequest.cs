using static FinanceManager.Domain.Entidades.Categoria;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.DTOs.DtosUpdate;

public class CategoriaUpdateRequest
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome da categoria deve ser informado!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O descrição deve ser informado!")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O tipo de lançamento deve ser informado!")]
    public TipoCategoria Tipo { get; set; } 
    
    [Required(ErrorMessage = "O código de cor deve ser informado!")]
    public string ColorCode { get; set; }
}

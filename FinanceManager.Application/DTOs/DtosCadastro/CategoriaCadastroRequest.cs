using System.ComponentModel.DataAnnotations;
using static FinanceManager.Domain.Entidades.Categoria;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class CategoriaCadastroRequest
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "O nome da categoria deve ser informado!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O descrição deve ser informado!")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O tipo de lançamento deve ser informado!")]
    public TipoCategoria Tipo { get; set; }
}

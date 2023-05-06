

using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface ICategoriaService
{
    Task IncluirAsync(CategoriaCadastroRequest Categoria);
    Task<IEnumerable<CategoriaResponse>> ObterAsync();
    Task<Categoria> ObterCategoriaByIdAsync(int? idCategoria);
}

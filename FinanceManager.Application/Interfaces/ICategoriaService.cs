

using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Application.Interfaces;

public interface ICategoriaService
{
    Task IncluirCategoriaAsync(CategoriaCadastroRequest Categoria);
    Task<IEnumerable<CategoriaResponse>> ObterCategoriaAsync();
}

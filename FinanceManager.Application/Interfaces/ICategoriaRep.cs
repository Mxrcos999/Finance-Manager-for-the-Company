

using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface ICategoriaRep
{
    Task<IEnumerable<CategoriaResponse>> ObterAsync();
    Task<IEnumerable<CategoriaResponse>> IncluirAsync(Categoria categoria);
    Task<Categoria> ObterCategoriaByIdAsync(int? idCategoria);
}

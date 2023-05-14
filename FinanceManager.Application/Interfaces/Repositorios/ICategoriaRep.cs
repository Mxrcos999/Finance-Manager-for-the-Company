using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces.Repositorios;

public interface ICategoriaRep
{
    Task<IEnumerable<CategoriaResponse>> ObterAsync();
    Task<IEnumerable<CategoriaResponse>> AlterarAsync(Categoria categoria);
    Task<IEnumerable<CategoriaResponse>> IncluirAsync(Categoria categoria);
    Task<Categoria> ObterCategoriaByIdAsync(int? idCategoria);
}

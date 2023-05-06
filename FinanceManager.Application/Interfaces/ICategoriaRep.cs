

using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;
using System.Threading.Tasks;

namespace FinanceManager.Application.Interfaces;

public interface ICategoriaRep
{
    Task<IEnumerable<CategoriaResponse>> ObtemCategoria(string idUser);
    Task IncluirCategoriaAsync(Categoria categoria, ApplicationUser user);
    Task<Categoria> ObterCategoriaByNomeAsync(int? idCategoria);
}


using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Services;


public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRep _categoriaRep;

    public CategoriaService(ICategoriaRep categoriaRep)
    {
        _categoriaRep = categoriaRep;
    }

    public async Task<IEnumerable<CategoriaResponse>> ObterCategoriaAsync(string idUser)
    {
        return await _categoriaRep.ObtemCategoria(idUser);
    }
    public async Task IncluirCategoria(CategoriaCadastroRequest categoria, ApplicationUser user)
    {
        var categoriaInserir = new Categoria(categoria.Nome, categoria.Descricao, categoria.Tipo.ToString());
    }
    public Task IncluirCategoriaAsync(CategoriaCadastroRequest Categoria)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoriaResponse>> ObterCategoriaAsync()
    {
        throw new NotImplementedException();
    }
}

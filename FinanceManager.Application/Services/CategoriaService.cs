using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.DTOs.DtosUpdate;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Entidades;
using FinanceManager.Domain.Factory;

namespace FinanceManager.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRep _categoriaRep;

    public CategoriaService(ICategoriaRep categoriaRep)
    {
        _categoriaRep = categoriaRep;
    }

    public async Task<IEnumerable<CategoriaResponse>> ObterAsync()
    {
        return await _categoriaRep.ObterAsync();
    }

    public async Task<IEnumerable<CategoriaResponse>> IncluirAsync(CategoriaCadastroRequest categoria)
    {
        var categoriaInserir = CategoriaFactory.
            Create(categoria.Nome,
            categoria.Descricao,
            categoria.Tipo.ToString());

        var categoriasAtualizadas = await _categoriaRep.IncluirAsync(categoriaInserir);

        if (categoriasAtualizadas is null)
            return null;
        return categoriasAtualizadas;
    }

    public async Task<Categoria> ObterByIdAsync(int? idCategoria)
    {
        var categoria = await _categoriaRep.ObterCategoriaByIdAsync(idCategoria);

        if (categoria is null)
            throw new Exception("Categoria não encontrada");

        return categoria;
    }

    public async Task<IEnumerable<CategoriaResponse>> AlterarAsync(CategoriaUpdateRequest categoria)
    {
        var categoriaObtida = await _categoriaRep.ObterCategoriaByIdAsync(categoria.Id);

        categoriaObtida.Alterar(categoria.Nome, categoria.Descricao, categoria.Tipo.ToString());

        return await _categoriaRep.AlterarAsync(categoriaObtida);
    }
}

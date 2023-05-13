﻿

using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaResponse>> IncluirAsync(CategoriaCadastroRequest categoria);
    Task<IEnumerable<CategoriaResponse>> ObterAsync();
    Task<Categoria> ObterByIdAsync(int? idCategoria);
}

﻿using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/categorias")]
public class CategoriaController
{
    private readonly ICategoriaService _categoriaService;
    private readonly UserManager<ApplicationUser> _userManager;

    public CategoriaController(ICategoriaService categoriaService, UserManager<ApplicationUser> userManager)
    {
        _categoriaService = categoriaService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoriaResponse>> GetCategoriaAsync()
    {
        return await _categoriaService.ObterAsync();
    }

    [HttpPost]
    public async Task PostEntradaAsync([FromBody] CategoriaCadastroRequest categoria)
    {
        await _categoriaService.IncluirAsync(categoria);
    }

    [HttpGet]
    public async Task<Categoria> GetCategoriaByIdAsync(int id)
    {
        return await _categoriaService.ObterCategoriaByIdAsync(id);

    }
       
}

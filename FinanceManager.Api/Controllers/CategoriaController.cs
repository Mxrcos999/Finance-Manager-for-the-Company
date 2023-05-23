using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.DTOs.DtosUpdate;
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
public class CategoriaController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoriaResponse>> ObterAsync([FromQuery] DateTime? dataInicial,[FromQuery] DateTime? dataFinal)
    {
        return await _categoriaService.ObterAsync(new HistoricoQuery(dataInicial, dataFinal));
    }

    [HttpPost]
    public async Task<IActionResult> IncluirAsync([FromBody] CategoriaCadastroRequest categoria)
    {
        var result = await _categoriaService.IncluirAsync(categoria);

        if (result is null)
            return BadRequest();

        return Ok(result);
    }

    [HttpGet("id")]
    public async Task<Categoria> ObterByIdAsync(int id)
    {
        return await _categoriaService.ObterByIdAsync(id);

    }

    [HttpPut]
    public async Task<IActionResult> AlterarAsync([FromBody] CategoriaUpdateRequest categoria)
    {
         var categorias = await _categoriaService.AlterarAsync(categoria);

        if(categorias is null)
            return BadRequest();
        
        return Ok(categorias);
    }  

}

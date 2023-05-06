using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Authorize]
[ApiController]
public class LancamentoRecorrenteController : Controller
{
    private readonly ILancamentoRecorrenteService _lancamentoRecorrenteService;

    public LancamentoRecorrenteController(ILancamentoRecorrenteService lancamentoRecorrenteService)
    {
        _lancamentoRecorrenteService = lancamentoRecorrenteService;
    }

    [HttpPost]
    [Route("api/lancamento-recorrente")]
    public async Task<IActionResult> PostLancamentoRecorrente(LancamentoRecorrenteCadastroRequest model)
    {
        if(!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest);

        await _lancamentoRecorrenteService.IncluirASync(model);

        return Ok();
    }
}

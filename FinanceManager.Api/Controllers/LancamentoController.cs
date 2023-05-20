using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.DTOs.DtosUpdate;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Authorize]
[ApiController]
public class LancamentoController : Controller
{
    private readonly ILancamentoService _lancamentoService;

    public LancamentoController(ILancamentoService lancamentoService)
    {
        _lancamentoService = lancamentoService;
    }

    [HttpGet]
    [Route("api/historico")]
    public async Task<IEnumerable<LancamentoResponse>> ObterAsync([FromQuery] DateTime? dataHoraInicial, [FromQuery] DateTime? dataHoraFinal)
    {
        return await _lancamentoService.ObterAsync(new HistoricoQuery(dataHoraInicial, dataHoraFinal));
    }

    [HttpPost]
    [Route("api/historico/lancamento")]
    public async Task<IActionResult> IncluirAsync([FromBody] LancamentoCadastroRequest lancamento)
    {
        var historico = await _lancamentoService.IncluirAsync(lancamento);

        if (historico is null)
            return BadRequest();

        return Ok(historico);
    } 
    
    [HttpPut]
    [Route("api/historico/lancamento")]
    public async Task<IActionResult> AlterarAsync([FromBody] LancamentoUpdateRequest lancamento)
    {
        var historico = await _lancamentoService.AlterarAsync(lancamento);

        if (historico is null)
            return BadRequest();

        return Ok(historico);
    }

    [HttpDelete]
    [Route("api/historico/lancamento")]
    public async Task<IActionResult> DeletarAsync([FromBody] int[] ids)
    {
        var result = await _lancamentoService.DeletarAsync(ids);

        return Ok(result);
    }
}

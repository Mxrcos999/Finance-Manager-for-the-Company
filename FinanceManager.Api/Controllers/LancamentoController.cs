using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
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
    private readonly ILancamentoService _contaFinanceiraService;

    public LancamentoController(ILancamentoService contaFinanceiraService, UserManager<ApplicationUser> userManager)
    {
        _contaFinanceiraService = contaFinanceiraService;
    }

    [HttpGet]
    [Route("api/historico")]
    public async Task<IEnumerable<LancamentoResponse>> GetContaFinanceirasASync([FromQuery] DateTime? dataHoraInicial, [FromQuery] DateTime? dataHoraFinal)
    {
        return await _contaFinanceiraService.ObterContasFinanceiras(new HistoricoQuery(dataHoraInicial, dataHoraFinal));
    }

    [HttpPost]
    [Route("api/historico/lancamento")]
    public async Task<IActionResult> PostEntradaASync([FromBody] LancamentoCadastroRequest conta)
    {
        var historico = await _contaFinanceiraService.IncluirContaFinanceira(conta);

        if (historico is null)
            return BadRequest();

        return Ok(historico);
    }
}

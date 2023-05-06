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
public class ContaFinanceiraController : Controller
{
    private readonly IContaFinanceiraService _contaFinanceiraService;

    public ContaFinanceiraController(IContaFinanceiraService contaFinanceiraService, UserManager<ApplicationUser> userManager)
    {
        _contaFinanceiraService = contaFinanceiraService;
    }

    [HttpGet]
    [Route("api/historico")]
    public async Task<IEnumerable<ContaFinanceiraResponse>> GetContaFinanceirasASync()
    {
        return await _contaFinanceiraService.ObterContasFinanceiras();
    }

    [HttpPost]
    [Route("api/historico/lancamento")]
    public async Task PostEntradaASync([FromBody] ContaFinanceiraCadastroRequest conta)
    {
        await _contaFinanceiraService.IncluirContaFinanceira(conta);
    }
}

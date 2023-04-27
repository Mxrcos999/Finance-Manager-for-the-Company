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
    private readonly UserManager<ApplicationUser> _userManager;

    public ContaFinanceiraController(IContaFinanceiraService contaFinanceiraService, UserManager<ApplicationUser> userManager)
    {
        _contaFinanceiraService = contaFinanceiraService;
        _userManager = userManager;
    }

    [HttpGet]
    [Route("api/conta-financeira")]
    public async Task<IEnumerable<ContaFinanceiraResponse>> GetContaFinanceirasASync()
    {
        var usuarioLogado = await _userManager.GetUserAsync(User);
        var id = usuarioLogado.Id;
        return await _contaFinanceiraService.ObterContasFinanceiras(id);
    }

    [HttpPost]
    [Route("api/historico/lancamento")]
    public async Task PostEntradaASync([FromBody] ContaFinanceiraCadastroRequest conta)
    {
        var usuarioLogado = await _userManager.GetUserAsync(User);
        await _contaFinanceiraService.IncluirContaFinanceira(conta, usuarioLogado);
    }
}

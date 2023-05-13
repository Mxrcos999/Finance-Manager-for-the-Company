using FinanceManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/pessoa-fisica")]
public class PessoaFisicaController : ControllerBase
{
    private readonly IPessoaFisicaService _pessoaFisicaService;

    public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService)
    {
        _pessoaFisicaService = pessoaFisicaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterPessoaFisicaAsync()
    {
        var pessoaFisica = await _pessoaFisicaService.ObterAsync();
        if (pessoaFisica is null)
            return BadRequest(pessoaFisica);

        return Ok(pessoaFisica);

    }
}

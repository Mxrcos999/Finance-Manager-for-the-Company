using FinanceManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/pessoa-juridica")]
public class PessoaJuridicaController : ControllerBase
{
    private readonly IPessoaJuridicaService _juridicaService;

    public PessoaJuridicaController(IPessoaJuridicaService juridicaService)
    {
        _juridicaService = juridicaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterAsync()
    {
        var pessoa = await _juridicaService.Obtersync();

        if (pessoa is null)
            return NotFound(pessoa);

        return Ok(pessoa);
    }
}

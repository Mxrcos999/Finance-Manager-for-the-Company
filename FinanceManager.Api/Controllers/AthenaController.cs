using FinanceManager.ServicosExternos.Dto;
using FinanceManager.ServicosExternos.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/servico-externo/openai/athena")]
public class AthenaController : Controller
{
    [HttpPost]
    public async Task<IActionResult> EnviaMensagemAsync(ChatAthenaCadastroRequest model)
    {
        var result = await OpenAiService.EnviaMensagem(model);

        return Ok(result.Choices);
    }
}

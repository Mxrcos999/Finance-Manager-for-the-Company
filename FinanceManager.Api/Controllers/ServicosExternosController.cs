using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.ServicosExternos.Dto;
using FinanceManager.ServicosExternos.ViaCep;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers;

[ApiController]
[Route("api/servicos-externos")]
public class ServicosExternosController : Controller
{
    [HttpGet("cep")]
    public async Task<FmsDefaultResponse> ObterEnderecoAsync(string cep)
    {
        var response = new FmsDefaultResponse();

        var endereco = await ViaCepService.ObtemEndereco(cep);
        if(endereco is null)
        {
            response.MensagemErro = "Não existe nenhum endereço para esse cep";
            response.Sucesso = false;
        }
        else
        {
            response.Dados = endereco;
            response.Sucesso = true;
        }

        return response;
        
    }
}

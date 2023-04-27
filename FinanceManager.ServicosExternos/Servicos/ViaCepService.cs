using FinanceManager.ServicosExternos.Dto;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace FinanceManager.ServicosExternos.ViaCep;

public static class ViaCepService
{
    public static async Task<EnderecoResponseViaCep> ObtemEndereco(string cep)
    {
        var client = new RestClient("https://viacep.com.br/ws/");
        var request = new RestRequest($"{cep}/json/", Method.Get);
        RestResponse response = await client.ExecuteAsync(request);
        if (response.StatusCode == HttpStatusCode.BadRequest)
            return null;

        var json = response.Content;
        var endereco = JsonConvert.DeserializeObject<EnderecoResponseViaCep>(json);
        return endereco;
    }
}

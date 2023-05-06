using FinanceManager.ServicosExternos.Dto;
using RestSharp;

namespace FinanceManager.ServicosExternos.Servicos;

public static class OpenAiService
{
    private static readonly string _apiKey = "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";
    private static readonly string _url = "/v1/engines/text-davinci-003/completions";
    public static async Task EnviaMensagem(ChatAthenaCadastroRequest model)
    {
        var client = new RestClient("https://api.openai.com/");
        var request = new RestRequest(_url, Method.Post);
        request.AddHeader("Authorization", $"Bearer {_apiKey}");
        request.AddHeader("Accept", "application/json");

        var requestBody = new
        {
            prompt = model.Mensagem,
            temperature = 0.5,
            max_tokens = 100
        };
        request.AddJsonBody(requestBody);

        var response = await client.ExecuteAsync(request);
        var result = response.Content;
    }
}

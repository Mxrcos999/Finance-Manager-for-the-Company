using FinanceManager.ServicosExternos.Dto;
using Newtonsoft.Json;
using RestSharp;

namespace FinanceManager.ServicosExternos.Servicos;

public static class OpenAiService
{
    private static readonly string _apiKey = "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";
    private static readonly string _url = "/v1/engines/text-davinci-003/completions";
    public static async Task<Root> EnviaMensagem(ChatAthenaCadastroRequest model)
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

        var result = await client.ExecuteAsync(request);
        var response = JsonConvert.DeserializeObject<Root>(result.Content);

        return response;
    }
}
public class Choice
{
    public string Text { get; set; }
    public string Identificador { get; private set; } = "Response";
    public int Index { get; set; }
    public object Logprobs { get; set; }
    public string Finish_reason { get; set; }
}

public class Root
{
    public string Id { get; set; }
    public int Created { get; set; }
    public string Model { get; set; }
    public List<Choice> Choices { get; set; }
    public Usage Usage { get; set; }
}

public class Usage
{
    public int Prompt_tokens { get; set; }
    public int Completion_tokens { get; set; }
    public int Total_tokens { get; set; }
}
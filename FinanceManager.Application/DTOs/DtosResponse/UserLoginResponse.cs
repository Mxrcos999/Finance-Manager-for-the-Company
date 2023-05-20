using System.Text.Json.Serialization;

namespace FinanceManager.Application.DTOs.DtosResponse;

public class UserLoginResponse
{

    public bool Success => Errors.Count == 0;

    public string Email { get; private set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string AccessToken { get; private set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RefreshToken { get; private set; }
    public IEnumerable<object> Dados { get; set; }

    public List<string> Errors { get; private set; }

    public UserLoginResponse()
    {
        Errors = new List<string>();
    }

    public UserLoginResponse(bool success)
        : this()
    {
    }

    public UserLoginResponse(bool success, string accessToken, string refreshToken)
        : this()
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public UserLoginResponse(bool success, string accessToken, string refreshToken, string email)
        : this()
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        Email = email;
    }

    public void AddError(string erro)
    {
        Errors.Add(erro);
    }

    public void AddErrors(IEnumerable<string> erros)
    {
        Errors.AddRange(erros);
    }

}


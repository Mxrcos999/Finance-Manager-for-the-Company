namespace FinanceManager.Application.DTOs.DtosResponse;

public sealed class UserRegisterResponse
{
    public bool Success => Errors.Count == 0;

    public List<string> Errors { get; private set; }
    public string SucessMessage { get; set; } 

    public UserRegisterResponse()
    {
        Errors = new List<string>();
    }

    public UserRegisterResponse(bool success)
        : this()
    {
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

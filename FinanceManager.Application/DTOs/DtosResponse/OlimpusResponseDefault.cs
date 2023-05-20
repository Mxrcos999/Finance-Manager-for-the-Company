namespace FinanceManager.Application.DTOs.DtosResponse;

public sealed class OlimpusResponseDefault
{
    public bool Status { get; set; }
    public IEnumerable<object> Dados { get; set; }
    public string Mensagem { get; set; }
}

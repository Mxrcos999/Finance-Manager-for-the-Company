namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class TelefoneCadastroRequest
{
    public string Ddd { get; set; }
    public string Ddi { get; set; }
    public string Numero { get; set; }
    public bool Principal { get; set; }
    public string Ramal { get; set; }
    public string TipoTelefone { get; set; }

}

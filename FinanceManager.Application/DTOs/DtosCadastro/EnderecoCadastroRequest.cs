namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class EnderecoCadastroRequest
{
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public string TipoLogradouro { get; set; }
}

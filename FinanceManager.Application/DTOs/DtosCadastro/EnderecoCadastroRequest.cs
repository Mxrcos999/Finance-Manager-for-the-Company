using static FinanceManager.Domain.Entidades.Endereco;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class EnderecoCadastroRequest
{
    public string Numero { get; set; }
    public string Logradouro { get; set; }
    public string Cep { get; set; }
    public string Uf { get; set; }
    public TiposLogradouro TipoLogradouro { get; set; }

}

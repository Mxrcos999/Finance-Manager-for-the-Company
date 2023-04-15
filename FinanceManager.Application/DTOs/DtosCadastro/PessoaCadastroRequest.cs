using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public abstract class PessoaCadastroRequest
{
    public List<EnderecoCadastroRequest> Enderecos { get; set; }
    public List<TelefoneCadastroRequest> Telefones { get; set; }
    public List<string> Email { get; set; }
}

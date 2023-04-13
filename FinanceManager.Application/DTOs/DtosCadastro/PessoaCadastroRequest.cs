using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class PessoaCadastroRequest
{
    public List<EnderecoCadastroRequest> Enderecos { get; set; }
    public List<TelefoneCadastroRequest> Telefones { get; set; }
    public List<string> Email { get; set; }
    public PessoaFisicaCadastroRequest? PessoaFisica { get; set; }
    public PessoaJuridicaCadastroRequest? PessoaJuridica { get; set; }
}

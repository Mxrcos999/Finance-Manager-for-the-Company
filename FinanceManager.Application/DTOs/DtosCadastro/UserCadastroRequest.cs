using static FinanceManager.Domain.Entidades.ApplicationUser;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class UserCadastroRequest
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public PessoaFisicaCadastroRequest? PessoaFisica { get; set; }
    public PessoaJuridicaCadastroRequest? PessoaJuridica { get; set; }

    public enum TipoUsuarioEnum
    {
        PessoaFisica,
        PessoaJuridica
    }
}

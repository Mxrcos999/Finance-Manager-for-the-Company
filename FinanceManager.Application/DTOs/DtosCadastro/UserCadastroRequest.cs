using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class UserCadastroRequest
{
    [Required(ErrorMessage = "O campo email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um email válido.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo senha é obrigatório.")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "O campo confirmar senha é obrigatório.")]
    [Compare("Senha", ErrorMessage = "As senhas não são iguais.")]
    public string ConfirmaSenha { get; set; }

    [Required(ErrorMessage = "O campo tipo do usuário é obrigatório.")]
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public PessoaFisicaCadastroRequest? PessoaFisica { get; set; }
    public PessoaJuridicaCadastroRequest? PessoaJuridica { get; set; }

    public enum TipoUsuarioEnum
    {
        PessoaFisica,
        PessoaJuridica
    }
}

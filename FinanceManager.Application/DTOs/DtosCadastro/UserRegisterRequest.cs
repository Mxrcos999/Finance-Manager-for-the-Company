using FinanceManager.Domain;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public class UserRegisterRequest
{
    public PessoaCadastroRequest Pessoa { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}

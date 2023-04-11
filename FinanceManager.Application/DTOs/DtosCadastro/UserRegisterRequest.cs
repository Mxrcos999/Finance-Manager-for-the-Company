using FinanceManager.Domain;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public class UserRegisterRequest
{
    public Pessoa Pessoa { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}

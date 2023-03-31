using FinanceManager.Domain;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public class UserRegisterRequest
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public List<Endereco> Enderecos { get; set; }
    public List<Telefone> Telefones { get; set; }
}

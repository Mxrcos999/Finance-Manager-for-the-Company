using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Domain;

public class ApplicationUser : IdentityUser
{
    public List<Endereco> Enderecos { get; set; }
    public List<Telefone> Telefones { get; set; }
}

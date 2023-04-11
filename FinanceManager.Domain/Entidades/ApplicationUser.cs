using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Domain.Entidades;

public class ApplicationUser : IdentityUser
{
    public Pessoa Pessoa { get; set; }
}

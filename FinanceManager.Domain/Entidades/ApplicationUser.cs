using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Domain.Entidades;

public class ApplicationUser : IdentityUser
{
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public int? PessoaFisicaId { get; set; }
    public int? PessoaJuridicaId { get; set; }

    [ForeignKey("PessoaFisicaId")]
    public virtual PessoaFisica? PessoaFisica { get; set; }

    [ForeignKey("PessoaJuridicaId")]
    public virtual PessoaJuridica? PessoaJuridica { get; set; }
    public enum TipoUsuarioEnum
    {
        PessoaFisica,
        PessoaJuridica
    }
}
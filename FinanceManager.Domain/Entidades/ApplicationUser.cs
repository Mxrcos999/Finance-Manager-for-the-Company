using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Domain.Entidades;

public class ApplicationUser : IdentityUser
{
    public ICollection<Lancamento> ContasFinanceiras { get; set; }
    public ICollection<LancamentoRecorrente> LancamentosRecorrentes { get; set; }
    public ICollection<Categoria> Categorias { get; set; }

    [ForeignKey("PessoaFisicaId")]
    public virtual PessoaFisica? PessoaFisica { get; set; }
    public int? PessoaFisicaId { get; set; }
    [ForeignKey("PessoaJuridicaId")]
    public virtual PessoaJuridica? PessoaJuridica { get; set; }
    public int? PessoaJuridicaId { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public decimal Saldo { get; set; }

}

public enum TipoUsuario
{
    PessoaFisica,
    PessoaJuridica
}
using FinanceManager.Domain.Entidades;
using FinanceManager.Infrastructure.Configuration;
using FinanceManager.Infrastructure.Mapeamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure;

public class FinanceManagerContext : IdentityDbContext<ApplicationUser>
{
    internal readonly IHttpContextAccessor _httpContextAccessor;
    public FinanceManagerContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public DbSet<ContaFinanceira> contasfinanceiras { get; set; }
    public DbSet<Categoria> categorias { get; set; }
    public DbSet<Telefone> telefones { get; set; }
    public DbSet<Endereco> enderecos { get; set; }
    public DbSet<ApplicationUser> applicationUsers { get; set; }
    public DbSet<PessoaFisica> pessoasfisicas { get; set; }
    public DbSet<PessoaJuridica> pessoasjuridicas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new PessoaFisicaMap());

        modelBuilder
            .ApplyConfiguration(new ContaFinanceiraMap());

        base.OnModelCreating(modelBuilder);
    }

}

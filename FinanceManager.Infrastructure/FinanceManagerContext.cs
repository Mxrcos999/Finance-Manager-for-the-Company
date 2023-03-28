using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure;

public class FinanceManagerContext : DbContext
{
    public FinanceManagerContext(DbContextOptions options) : base(options) { }
    public DbSet<ContaFinanceira> contaFinanceiras { get; set; }
    public DbSet<Entrada> entradas { get; set; }
    public DbSet<Saida> saidas { get; set; }
    public DbSet<Categoria> categorias { get; set; }
}

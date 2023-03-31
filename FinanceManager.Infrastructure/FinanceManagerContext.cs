﻿using FinanceManager.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure;

public class FinanceManagerContext : IdentityDbContext<ApplicationUser>
{
    public FinanceManagerContext(DbContextOptions options) : base(options) { }
    public DbSet<ContaFinanceira> contasfinanceiras { get; set; }
    public DbSet<Entrada> entradas { get; set; }
    public DbSet<Saida> saidas { get; set; }
    public DbSet<Categoria> categorias { get; set; }
    public DbSet<Telefone> telefones { get; set; }
    public DbSet<Endereco> enderecos { get; set; }
    public DbSet<ApplicationUser> applicationUsers { get; set; }
}

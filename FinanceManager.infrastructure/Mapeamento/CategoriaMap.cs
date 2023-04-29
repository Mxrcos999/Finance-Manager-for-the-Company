using FinanceManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Mapeamento;

public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder
            .HasMany(wm => wm.ContaFinanceira)
            .WithOne(wo => wo.Categorias)
            .HasForeignKey(fk => fk.CategoriaId);
    }
}

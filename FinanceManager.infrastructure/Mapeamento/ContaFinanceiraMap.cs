using FinanceManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Mapeamento;

public class ContaFinanceiraMap : IEntityTypeConfiguration<ContaFinanceira>
{
    public void Configure(EntityTypeBuilder<ContaFinanceira> builder)
    {
        builder
             .HasOne(o => o.Usuario)
             .WithMany(wm => wm.ContasFinanceiras)
             .HasForeignKey(fk => fk.UsuarioId)
             .HasConstraintName("fk_conta_financeira_user_id");       
    }
}

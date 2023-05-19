using FinanceManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Mapeamento;

public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
{
    public void Configure(EntityTypeBuilder<Lancamento> builder)
    {
        builder
             .HasOne(o => o.Usuario)
             .WithMany(wm => wm.ContasFinanceiras)
             .HasForeignKey(fk => fk.UsuarioId)
             .HasConstraintName("fk_conta_financeira_user_id");       
    }
}

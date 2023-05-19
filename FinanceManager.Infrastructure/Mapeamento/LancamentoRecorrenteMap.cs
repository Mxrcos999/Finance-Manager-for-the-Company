using FinanceManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Mapeamento;

public class LancamentoRecorrenteMap : IEntityTypeConfiguration<LancamentoRecorrente>
{
    public void Configure(EntityTypeBuilder<LancamentoRecorrente> builder)
    {
        builder
            .HasOne(o => o.Usuario)
            .WithMany(wm => wm.LancamentosRecorrentes)
            .HasForeignKey(o => o.UsuarioId)
            .HasConstraintName("fk_lancamento_recorrente_user_id");

    }
}

using FinanceManager.Domain.Entidades;
using FinanceManager.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace FinanceManager.Infrastructure.Configuration;

public class PessoaFisicaMap : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        var CpfConverter = new ValueConverter<Cpf, string>(v => v.ToString(), v => Cpf.Parse(v));

        builder
            .Property(pf => pf.Cpf)
            .HasConversion(CpfConverter);


    }
}

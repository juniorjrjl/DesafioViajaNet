using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.TypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class CidadeTypeConfiguration : AbstractTypeConfiguration<Cidade>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<Cidade> builder)
        {
            builder.Property(c => c.Codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("CODIGO");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("DESCRICAO");
        }

        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<Cidade> builder) => builder.HasOne(fk => fk.Estado)
            .WithMany(fk => fk.Cidades)
            .HasConstraintName("FK_CIDADES_ESTADOS")
            .IsRequired();

        protected override void ConfigurarChavesPrimaria(EntityTypeBuilder<Cidade> builder) => builder.HasKey(pk => new { pk.Codigo });

        protected override void ConfigurarIndices(EntityTypeBuilder<Cidade> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<Cidade> builder) => builder.ToTable("CIDADES");
    }
}

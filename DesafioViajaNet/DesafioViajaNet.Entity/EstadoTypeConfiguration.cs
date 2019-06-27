using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class EstadoTypeConfiguration : AbstractTypeConfiguration<Estado>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<Estado> builder)
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

        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<Estado> builder) => builder.HasMany(fk => fk.Cidades)
            .WithOne(fk => fk.Estado)
            .OnDelete(DeleteBehavior.Cascade);

        protected override void ConfigurarChavesPrimaria(EntityTypeBuilder<Estado> builder) => builder.HasKey(pk => new { pk.Codigo});

        protected override void ConfigurarIndices(EntityTypeBuilder<Estado> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<Estado> builder) => builder.ToTable("ESTADOS");
    }
}

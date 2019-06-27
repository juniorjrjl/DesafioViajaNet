using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class ViagemTypeConfiguration : AbstractTypeConfiguration<Viagem>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<Viagem> builder)
        {
            builder.Property(c => c.Codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("CODIGO");

            builder.Property(c => c.CodigoOrigem)
                .IsRequired()
                .HasColumnName("CODIGO_ORIGEM");

            builder.Property(c => c.CodigoDestino)
                .IsRequired()
                .HasColumnName("CODIGO_DESTINO");

        }

        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<Viagem> builder)
        {
            builder.HasOne(fk => fk.Destino)
                .WithMany(fk => fk.Destinos)
                .HasForeignKey(fk => fk.CodigoDestino)
                .HasConstraintName("FK_VIAGENS_DESTINOS")
                .IsRequired();

            builder.HasOne(fk => fk.Origem)
                .WithMany(fk => fk.Origens)
                .HasForeignKey(fk => fk.CodigoOrigem)
                .HasConstraintName("FK_VIAGENS_ORIGENS")
                .IsRequired();
        }

        protected override void ConfigurarChavesPrimaria(EntityTypeBuilder<Viagem> builder) => builder.HasKey(pk => new { pk.Codigo });

        protected override void ConfigurarIndices(EntityTypeBuilder<Viagem> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<Viagem> builder) => builder.ToTable("VIAGEM");
    }
}

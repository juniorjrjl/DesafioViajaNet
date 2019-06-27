using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class LandingComportamentoTypeConfiguration : AbstractComportamentoTypeConfiguration<LandingComportamento>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<LandingComportamento> builder)
        {
            base.ConfigurarCamposTabela(builder);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("NOME");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("EMAIL");

            builder.Property(c => c.DataViagem)
                .IsRequired()
                .HasColumnName("DATA_VIAGEM");

            builder.Property(c => c.DiasVagem)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("DIAS_VIAGEM");

            builder.Property(c => c.CodigoOrigem)
                .IsRequired()
                .HasColumnName("CODIGO_ORIGEM");

            builder.Property(c => c.CodigoDestino)
                .IsRequired()
                .HasColumnName("CODIGO_DESTINO");

        }
        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<LandingComportamento> builder)
        {
            builder.HasOne(fk => fk.Destino)
                .WithOne(fk => fk.LandingComportamentoDestino)
                .HasConstraintName("FK_LANDING_CIDADES_DESTINO")
                .HasForeignKey<LandingComportamento>(fk => fk.CodigoDestino)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(fk => fk.Origem)
                .WithOne(fk => fk.LandingComportamentoOrigem)
                .HasConstraintName("FK_LANDING_CIDADES_ORIGEM")
                .HasForeignKey<LandingComportamento>(fk => fk.CodigoOrigem)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }

        protected override void ConfigurarIndices(EntityTypeBuilder<LandingComportamento> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<LandingComportamento> builder) => builder.ToTable("LANDING_COMPORTAMENTOS");
    }
}

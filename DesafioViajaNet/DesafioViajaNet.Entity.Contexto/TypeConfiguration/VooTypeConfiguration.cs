using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class VooTypeConfiguration : AbstractTypeConfiguration<Voo>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<Voo> builder)
        {
            builder.Property(c => c.Codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("CODIGO");

            builder.Property(c => c.Preco)
                .IsRequired()
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("PRECO");

            builder.Property(c => c.DataHoraEmbarque)
                .IsRequired()
                .HasColumnName("DATA_HORA_EMBARQUE");

            builder.Property(c => c.DataHoraDesembarque)
                .IsRequired()
                .HasColumnName("DATA_HORA_DESEMBARQUE");

            builder.Property(c => c.CodigoViagem)
                .IsRequired()
                .HasColumnName("CODIGO_VIAGEM");

        }

        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<Voo> builder)
        {
            builder.HasOne(fk => fk.Viagem)
                .WithMany(fk => fk.Voos)
                .HasForeignKey(fk => fk.CodigoViagem)
                .HasConstraintName("FK_VOOS_VIAGENS")
                .IsRequired();
        }

        protected override void ConfigurarChavesPrimaria(EntityTypeBuilder<Voo> builder) => builder.HasKey(pk => new { pk.Codigo });

        protected override void ConfigurarIndices(EntityTypeBuilder<Voo> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<Voo> builder) => builder.ToTable("VOO");
    }
}

using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public abstract class AbstractComportamentoTypeConfiguration<TEntidate> : AbstractTypeConfiguration<TEntidate> where TEntidate : AbstractComportamento
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<TEntidate> builder)
        {
            builder.Property(c => c.Codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("CODIGO");

            builder.Property(c => c.IP)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("IP");

            builder.Property(c => c.NomePagina)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("NOME_PAGINA");

            builder.Property(c => c.Browser)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("BROWSER");
        }

        protected override void ConfigurarChavesPrimaria(EntityTypeBuilder<TEntidate> builder) => builder.HasKey(pk => new { pk.Codigo });
    }
}

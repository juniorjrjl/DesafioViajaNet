using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class UsuarioTypeConfiguration : AbstractTypeConfiguration<Usuario>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("NOME");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("EMAIL");
        }

        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<Usuario> builder) { }

        protected override void ConfigurarChavesPrimaria(EntityTypeBuilder<Usuario> builder) => builder.HasKey(pk => new { pk.Codigo });

        protected override void ConfigurarIndices(EntityTypeBuilder<Usuario> builder) {}

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<Usuario> builder) => builder.ToTable("USUARIOS");
    }
}

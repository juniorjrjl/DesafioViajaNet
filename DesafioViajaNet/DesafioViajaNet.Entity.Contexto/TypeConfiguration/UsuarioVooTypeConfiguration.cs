using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class UsuarioVooTypeConfiguration : AbstractTypeConfiguration<UsuarioVoo>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<UsuarioVoo> builder)
        {
            builder.Property(c => c.CodigoUsuario)
                .IsRequired()
                .HasColumnName("CODIGO_USUARIO");

            builder.Property(c => c.CodigoVoo)
                .IsRequired()
                .HasColumnName("CODIGO_VOO");

            builder.Property(c => c.Preco)
                .IsRequired()
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("PRECO");
        }

        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<UsuarioVoo> builder)
        {
            builder.HasOne(fk => fk.Usuario)
                .WithMany(fk => fk.UsuariosVoos)
                .HasForeignKey(fk => fk.CodigoUsuario)
                .HasConstraintName("FK_USUARIOS_USUARIOS_VOOS")
                .IsRequired();

            builder.HasOne(fk => fk.Voo)
                .WithMany(fk => fk.UsuariosVoos)
                .HasForeignKey(fk => fk.CodigoVoo)
                .HasConstraintName("FK_VOOS_USUARIOS_VOOS")
                .IsRequired();
        }

        protected override void ConfigurarChavesPrimaria(EntityTypeBuilder<UsuarioVoo> builder) => builder.HasKey(pk => new { pk.CodigoUsuario, pk.CodigoVoo });

        protected override void ConfigurarIndices(EntityTypeBuilder<UsuarioVoo> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<UsuarioVoo> builder) => builder.ToTable("USUARIOS_VOOS");
    }
}

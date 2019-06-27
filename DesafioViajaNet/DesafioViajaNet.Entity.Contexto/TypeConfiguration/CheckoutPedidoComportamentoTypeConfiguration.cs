using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class CheckoutPedidoComportamentoTypeConfiguration : AbstractComportamentoTypeConfiguration<CheckoutPedidoComportamento>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<CheckoutPedidoComportamento> builder)
        {
            base.ConfigurarCamposTabela(builder);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("EMAIL");

            builder.Property(c => c.CodigoVoo)
                .IsRequired()
                .HasColumnName("CODIGO_VOO");
        }

        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<CheckoutPedidoComportamento> builder)
        {
            builder.HasOne(fk => fk.Voo)
                .WithMany(fk => fk.CheckoutPedidoComportamentos)
                .HasForeignKey(fk => fk.CodigoVoo)
                .HasConstraintName("FK_CHECKOUT_COMPORTAMENTO_VOO")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }

        protected override void ConfigurarIndices(EntityTypeBuilder<CheckoutPedidoComportamento> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<CheckoutPedidoComportamento> builder) => builder.ToTable("CHECKOUT_COMPORTAMENTO");
    }
}

using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class ConfirmacaoPedidoComportamentoTypeConfiguration : AbstractComportamentoTypeConfiguration<ConfirmacaoPedidoComportamento>
    {
        protected override void ConfigurarCamposTabela(EntityTypeBuilder<ConfirmacaoPedidoComportamento> builder)
        {
            base.ConfigurarCamposTabela(builder);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("EMAIL");

            builder.Property(c => c.Confirmou)
                .IsRequired()
                .HasColumnName("CONFIRMOU");

            builder.Property(c => c.CodigoVoo)
                .IsRequired()
                .HasColumnName("CODIGO_VOO");
        }

        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<ConfirmacaoPedidoComportamento> builder)
        {
            builder.HasOne(fk => fk.Voo)
                .WithMany(fk => fk.ConfirmacaoPedidoComportamentos)
                .HasForeignKey(fk => fk.CodigoVoo)
                .HasConstraintName("FK_PEDIDO_COMPORTAMENTO_VOO")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }

        protected override void ConfigurarIndices(EntityTypeBuilder<ConfirmacaoPedidoComportamento> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<ConfirmacaoPedidoComportamento> builder) => builder.ToTable("CONFIRMACAO_PEDIDO_COMPORTAMENTO");
    }
}

using DesafioViajaNet.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public class HomeComportamentoTypeConfiguration : AbstractComportamentoTypeConfiguration<HomeComportamento>
    {
        protected override void ConfigurarChavesEstrangeiras(EntityTypeBuilder<HomeComportamento> builder) { }

        protected override void ConfigurarIndices(EntityTypeBuilder<HomeComportamento> builder) { }

        protected override void ConfigurarNomeTabela(EntityTypeBuilder<HomeComportamento> builder) => builder.ToTable("HOME_COMPORTAMENTO");
    }
}

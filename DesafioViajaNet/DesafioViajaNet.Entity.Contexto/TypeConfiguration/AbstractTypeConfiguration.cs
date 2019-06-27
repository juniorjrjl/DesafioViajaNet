using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.TypeConfiguration
{
    public abstract class AbstractTypeConfiguration<TEntidade> : IEntityTypeConfiguration<TEntidade> where TEntidade : class
    {
        public void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            ConfigurarNomeTabela(builder);
            ConfigurarCamposTabela(builder);
            ConfigurarChavesPrimaria(builder);
            ConfigurarChavesEstrangeiras(builder);
            ConfigurarIndices(builder);
        }

        protected abstract void ConfigurarNomeTabela(EntityTypeBuilder<TEntidade> builder);

        protected abstract void ConfigurarCamposTabela(EntityTypeBuilder<TEntidade> builder);

        protected abstract void ConfigurarChavesPrimaria(EntityTypeBuilder<TEntidade> builder);

        protected abstract void ConfigurarChavesEstrangeiras(EntityTypeBuilder<TEntidade> builder);

        protected abstract void ConfigurarIndices(EntityTypeBuilder<TEntidade> builder);

    }
}

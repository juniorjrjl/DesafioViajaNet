using DesafioViajaNet.RepositorioGenerico;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class RepositorioGenericoComposto<TEntidade> : IRepositorioComposto<TEntidade>
        where TEntidade : class
    {

        protected DesafioViajaNetDbContext _contexto;

        public RepositorioGenericoComposto(DesafioViajaNetDbContext contexto) => _contexto = contexto;

        public TEntidade Alterar(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            return entidade;
        }

        public void Excluir(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Deleted;
        }

        public TEntidade Inserir(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Add(entidade);
            return entidade;
        }

        public List<TEntidade> Selecionar() => _contexto.Set<TEntidade>().ToList();

        public void AplicarAlteracoes() => _contexto.SaveChanges();
    }
}

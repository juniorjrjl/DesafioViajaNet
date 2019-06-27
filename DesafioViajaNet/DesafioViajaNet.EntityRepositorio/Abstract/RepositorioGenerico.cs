using DesafioViajaNet.RepositorioGenerico;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class RepositorioGenerico<TEntidade, TChave> : IRepositorio<TEntidade, TChave>
        where TEntidade : class
    {
        protected DesafioViajaNetDbContext _contexto;

        public RepositorioGenerico(DesafioViajaNetDbContext contexto) => _contexto = contexto;

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

        public void Excluir(TChave id) => Excluir(Selecionar(id));

        public TEntidade Inserir(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Add(entidade);
            return entidade;
        }

        public List<TEntidade> Selecionar() => _contexto.Set<TEntidade>().ToList();

        public TEntidade Selecionar(TChave id) => _contexto.Set<TEntidade>().Find(id);

        public void AplicarAlteracoes() => _contexto.SaveChanges();

    }
}

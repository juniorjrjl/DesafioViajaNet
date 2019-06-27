using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractUsuarioRepositorio : RepositorioGenerico<Usuario, long>
    {
        public AbstractUsuarioRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
        public abstract long BuscarCodigoPeloEmail(string email);
    }
}

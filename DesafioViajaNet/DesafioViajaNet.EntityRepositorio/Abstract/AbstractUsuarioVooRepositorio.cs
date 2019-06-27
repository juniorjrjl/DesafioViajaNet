using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractUsuarioVooRepositorio : RepositorioGenericoComposto<UsuarioVoo>
    {
        public AbstractUsuarioVooRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}

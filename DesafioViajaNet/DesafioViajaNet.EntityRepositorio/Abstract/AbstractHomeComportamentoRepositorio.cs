using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractHomeComportamentoRepositorio : RepositorioGenerico<HomeComportamento, long>
    {
        public AbstractHomeComportamentoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}

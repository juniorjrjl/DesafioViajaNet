using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractLandingComportamentoRepositorio : RepositorioGenerico<LandingComportamento, long>
    {
        public AbstractLandingComportamentoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}

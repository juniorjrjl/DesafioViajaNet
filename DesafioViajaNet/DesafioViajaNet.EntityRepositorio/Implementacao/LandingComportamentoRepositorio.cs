using DesafioViajaNet.Entity.Repositorio.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class LandingComportamentoRepositorio : AbstractLandingComportamentoRepositorio
    {
        public LandingComportamentoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}

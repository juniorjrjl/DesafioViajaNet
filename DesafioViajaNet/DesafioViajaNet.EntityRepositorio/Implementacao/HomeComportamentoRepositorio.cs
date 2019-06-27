using DesafioViajaNet.Entity.Repositorio.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class HomeComportamentoRepositorio : AbstractHomeComportamentoRepositorio
    {
        public HomeComportamentoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}

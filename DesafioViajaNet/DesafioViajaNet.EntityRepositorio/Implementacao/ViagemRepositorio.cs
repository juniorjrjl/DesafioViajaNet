using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class ViagemRepositorio : AbstractViagemRepositorio
    {
        public ViagemRepositorio(DesafioViajaNetDbContext contexto) : base(contexto){ }
    }
}

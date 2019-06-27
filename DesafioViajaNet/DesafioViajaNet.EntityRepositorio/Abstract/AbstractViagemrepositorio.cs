using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractViagemRepositorio : RepositorioGenerico<Viagem, long>
    {
        public AbstractViagemRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}

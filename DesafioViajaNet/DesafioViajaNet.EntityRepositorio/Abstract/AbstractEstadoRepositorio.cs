using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractEstadoRepositorio : RepositorioGenerico<Estado, long>
    {
        public AbstractEstadoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }

        public abstract IList<EstadoComboDTO> BuscarTodos();

    }
}

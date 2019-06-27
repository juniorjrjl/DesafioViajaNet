using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractCidadeRepositorio : RepositorioGenerico<Cidade, long>
    {
        public AbstractCidadeRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }

        public abstract IList<CidadeComboDTO> BuscarPorEstado(long idEstado);

    }
}

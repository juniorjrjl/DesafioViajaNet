using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractVooRepositorio : RepositorioGenerico<Voo, long>
    {
        public AbstractVooRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
        public abstract IList<ViagemVooDTO> BuscarVooPeriodo(DateTime dataEmbarque, DateTime dataDesembarque, long codigoDestino);
        public abstract ViagemVooDetalheDTO BuscarDetalhes(long codigoVoo);
        public abstract decimal BuscarPreco(long codigoVoo);
    }
}

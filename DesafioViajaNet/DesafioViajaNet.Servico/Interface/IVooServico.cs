using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Interface
{
    public interface IVooServico
    {
        Voo Inserir(Voo Voo);
        IList<ViagemVooDTO> BuscarVooPeriodo(DateTime dataEmbarque, DateTime dataDesembarque, long codigoDestino);
        ViagemVooDetalheDTO BuscarDetalhes(long codigoVoo);
        decimal BuscarPreco(long codigoVoo);
    }
}

using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class VooServico : IVooServico
    {
        private readonly AbstractVooRepositorio _vooRepositorio;

        public VooServico(AbstractVooRepositorio vooRepositorio) => _vooRepositorio = vooRepositorio;

        public ViagemVooDetalheDTO BuscarDetalhes(long codigoVoo) => _vooRepositorio.BuscarDetalhes(codigoVoo);

        public decimal BuscarPreco(long codigoVoo) => _vooRepositorio.BuscarPreco(codigoVoo);

        public IList<ViagemVooDTO> BuscarVooPeriodo(DateTime dataEmbarque, DateTime dataDesembarque, long codigoDestino) => _vooRepositorio.BuscarVooPeriodo(dataEmbarque, dataDesembarque, codigoDestino);

        public Voo Inserir(Voo Voo)
        {
            _vooRepositorio.Inserir(Voo);
            _vooRepositorio.AplicarAlteracoes();
            return Voo;
        }
    }
}

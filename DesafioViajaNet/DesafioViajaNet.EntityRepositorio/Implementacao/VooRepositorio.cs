using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class VooRepositorio : AbstractVooRepositorio
    {
        public VooRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }

        public override ViagemVooDetalheDTO BuscarDetalhes(long codigoVoo) => _contexto.Set<Voo>()
            .Where(v => v.Codigo == codigoVoo)
            .Select(v => new ViagemVooDetalheDTO
            {
                CodigoVoo = v.Codigo,
                DataHoraDesembarque = v.DataHoraDesembarque,
                DataHoraEmbarque = v.DataHoraEmbarque,
                Destino = new LocalViagemDTO
                {
                    Cidade = v.Viagem.Destino.Descricao,
                    Estado = v.Viagem.Destino.Estado.Descricao
                },
                Origem = new LocalViagemDTO
                {
                    Cidade = v.Viagem.Origem.Descricao,
                    Estado = v.Viagem.Origem.Estado.Descricao
                },
                Preco = v.Preco
            }).Single();

        public override decimal BuscarPreco(long codigoVoo) => _contexto.Set<Voo>()
            .Where(v => v.Codigo == codigoVoo)
            .Select(v => v.Preco)
            .Single();

        public override IList<ViagemVooDTO> BuscarVooPeriodo(DateTime dataEmbarque, DateTime dataDesembarque, long codigoDestino) => _contexto.Set<Voo>()
            .Where(v => v.DataHoraEmbarque.Date == dataEmbarque.Date && v.DataHoraDesembarque.Date == dataDesembarque.Date && v.Viagem.Destino.Codigo == codigoDestino)
            .Select(v => new ViagemVooDTO
            {
                CidadeDestino = v.Viagem.Destino.Descricao,
                CidadeOrigem = v.Viagem.Origem.Descricao,
                CodigoVoo = v.Codigo,
                DataHoraDesembarque = v.DataHoraDesembarque,
                DataHoraEmbarque = v.DataHoraEmbarque,
                Preco = v.Preco
            }).OrderBy(v => v.DataHoraEmbarque ).ThenBy(v=> v.DataHoraDesembarque)
            .ToList();
    }
}

using DesafioViajaNet.CouchDB.Repositorio.Implementacao;
using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class ConfirmacaoPedidoComportamentoServico : IConfirmacaoPedidoComportamentoServico
    {

        private readonly AbstractConfirmacaoPedidoComportamentoRepositorio _confirmacaoPedidoComportamentoEntity;
        private readonly ConfirmacaoPedidoComportamentoRepositorio _confirmacaoPedidoComportamentoCouchDB;
        public ConfirmacaoPedidoComportamentoServico(
            AbstractConfirmacaoPedidoComportamentoRepositorio confirmacaoPedidoComportamentoEntity,
            ConfirmacaoPedidoComportamentoRepositorio confirmacaoPedidoComportamentoCouchDB)
        {
            _confirmacaoPedidoComportamentoEntity = confirmacaoPedidoComportamentoEntity;
            _confirmacaoPedidoComportamentoCouchDB = confirmacaoPedidoComportamentoCouchDB;
        }

        public ConfirmacaoPedidoComportamento Inserir(ConfirmacaoPedidoComportamento confirmacaoPedidoComportamento)
        {
            _confirmacaoPedidoComportamentoEntity.Inserir(confirmacaoPedidoComportamento);
            _confirmacaoPedidoComportamentoEntity.AplicarAlteracoes();
            _confirmacaoPedidoComportamentoCouchDB.Inserir(confirmacaoPedidoComportamento);
            return confirmacaoPedidoComportamento;
        }
    }
}

using DesafioViajaNet.CouchDB.Repositorio.Implementacao;
using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class CheckoutPedidoComportamentoServico : ICheckoutPedidoComportamentoServico
    {
        private readonly AbstractCheckoutPedidoComportamentoRepositorio _checkoutPedidoComportamentoEntity;
        private readonly CheckoutPedidoComportamentoRepositorio _checkoutPedidoComportamentoCouchDB;

        public CheckoutPedidoComportamentoServico(
            AbstractCheckoutPedidoComportamentoRepositorio checkoutPedidoComportamentoEntity,
            CheckoutPedidoComportamentoRepositorio checkoutPedidoComportamentoCouchDB)
        {
            _checkoutPedidoComportamentoEntity = checkoutPedidoComportamentoEntity;
            _checkoutPedidoComportamentoCouchDB = checkoutPedidoComportamentoCouchDB;
        }

        public CheckoutPedidoComportamento Inserir(CheckoutPedidoComportamento checkoutPedidoComportamento)
        {
            _checkoutPedidoComportamentoEntity.Inserir(checkoutPedidoComportamento);
            _checkoutPedidoComportamentoEntity.AplicarAlteracoes();
            _checkoutPedidoComportamentoCouchDB.Inserir(checkoutPedidoComportamento);
            return checkoutPedidoComportamento;
        }
    }
}

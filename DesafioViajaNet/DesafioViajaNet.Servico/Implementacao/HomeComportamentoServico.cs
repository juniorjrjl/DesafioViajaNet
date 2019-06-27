using DesafioViajaNet.CouchDB.Repositorio.Implementacao;
using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class HomeComportamentoServico : IHomeComportamentoServico
    {

        private readonly AbstractHomeComportamentoRepositorio _homeComportamentoEntity;
        private readonly HomeComportamentoRepositorio _homeComportamentoCouchDB;

        public HomeComportamentoServico(
            AbstractHomeComportamentoRepositorio homeComportamentoEntity,
            HomeComportamentoRepositorio homeComportamentoCouchDB)
        {
            _homeComportamentoEntity = homeComportamentoEntity;
            _homeComportamentoCouchDB = homeComportamentoCouchDB;
        }

        public HomeComportamento Inserir(HomeComportamento homeComportamento)
        {
            _homeComportamentoEntity.Inserir(homeComportamento);
            _homeComportamentoEntity.AplicarAlteracoes();
            return homeComportamento;
        }
    }
}

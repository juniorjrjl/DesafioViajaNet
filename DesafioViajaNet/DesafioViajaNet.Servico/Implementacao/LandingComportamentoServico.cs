using DesafioViajaNet.CouchDB.Repositorio.Implementacao;
using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class LandingComportamentoServico : ILandingComportamentoServico
    {

        private readonly AbstractLandingComportamentoRepositorio _landingComportamentoEntity;
        private readonly LandingComportamentoRepositorio _landingComportamentoCouchDB;

        public LandingComportamentoServico(
            AbstractLandingComportamentoRepositorio landingComportamentoEntity,
            LandingComportamentoRepositorio landingComportamentoCouchDB)
        {
            _landingComportamentoEntity = landingComportamentoEntity;
            _landingComportamentoCouchDB = landingComportamentoCouchDB;
        }

        public LandingComportamento Inserir(LandingComportamento landingComportamento)
        {
            _landingComportamentoEntity.Inserir(landingComportamento);
            _landingComportamentoEntity.AplicarAlteracoes();
            _landingComportamentoCouchDB.Inserir(landingComportamento);
            return landingComportamento;
        }
    }
}

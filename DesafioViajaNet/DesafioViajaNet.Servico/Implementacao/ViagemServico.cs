using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class ViagemServico : IViagemServico
    {
        private readonly AbstractViagemRepositorio _viagemRepositorio;

        public ViagemServico(AbstractViagemRepositorio viagemRepositorio) => _viagemRepositorio = viagemRepositorio;

        public Viagem Inserir(Viagem viagem)
        {
            _viagemRepositorio.Inserir(viagem);
            _viagemRepositorio.AplicarAlteracoes();
            return viagem;
        }
    }
}

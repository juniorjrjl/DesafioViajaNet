using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class CidadeServico : ICidadeServico
    {
        private readonly AbstractCidadeRepositorio _cidadeRepositorio;

        public CidadeServico(AbstractCidadeRepositorio cidadeRepositorio) => _cidadeRepositorio = cidadeRepositorio;

        public IList<CidadeComboDTO> BuscarPorEstado(long idEstado) => _cidadeRepositorio.BuscarPorEstado(idEstado);

        public Cidade Inserir(Cidade cidade)
        {
            _cidadeRepositorio.Inserir(cidade);
            _cidadeRepositorio.AplicarAlteracoes();
            return cidade;
        }
    }
}

using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class EstadoServico : IEstadoServico
    {

        private readonly AbstractEstadoRepositorio _estadoRepositorio;

        public EstadoServico(AbstractEstadoRepositorio estadoRepositorio) => _estadoRepositorio = estadoRepositorio;

        public IList<EstadoComboDTO> BuscarTodos() => _estadoRepositorio.BuscarTodos();

        public Estado Inserir(Estado estado)
        {
            _estadoRepositorio.Inserir(estado);
            _estadoRepositorio.AplicarAlteracoes();
            return estado;
        }
    }
}

using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly AbstractUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(AbstractUsuarioRepositorio usuarioRepositorio) => _usuarioRepositorio = usuarioRepositorio;

        public long BuscarCodigoPeloEmail(string email) => _usuarioRepositorio.BuscarCodigoPeloEmail(email);

        public Usuario Inserir(Usuario usuario)
        {
            _usuarioRepositorio.Inserir(usuario);
            _usuarioRepositorio.AplicarAlteracoes();
            return usuario;
        }
    }
}

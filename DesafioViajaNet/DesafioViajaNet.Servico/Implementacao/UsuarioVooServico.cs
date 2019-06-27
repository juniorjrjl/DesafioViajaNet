using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Implementacao
{
    public class UsuarioVooServico : IUsuarioVooServico
    {
        private readonly AbstractUsuarioVooRepositorio _usuarioVooRepositorio;

        public UsuarioVooServico(AbstractUsuarioVooRepositorio usuarioVooRepositorio) => _usuarioVooRepositorio = usuarioVooRepositorio;

        public UsuarioVoo Inserir(UsuarioVoo usuarioVoo)
        {
            _usuarioVooRepositorio.Inserir(usuarioVoo);
            _usuarioVooRepositorio.AplicarAlteracoes();
            return usuarioVoo;
        }
    }
}

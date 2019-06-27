using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Interface
{
    public interface IUsuarioServico
    {
        Usuario Inserir(Usuario usuario);
        long BuscarCodigoPeloEmail(string email);
    }
}

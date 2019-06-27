using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Interface
{
    public interface IUsuarioVooServico
    {
        UsuarioVoo Inserir(UsuarioVoo usuarioVoo);
    }
}

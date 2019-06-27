using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Interface
{
    public interface IEstadoServico
    {
        Estado Inserir(Estado estado);
        IList<EstadoComboDTO> BuscarTodos();
    }
}

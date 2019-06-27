using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Interface
{
    public interface ICidadeServico
    {
        Cidade Inserir(Cidade cidade);
        IList<CidadeComboDTO> BuscarPorEstado(long idEstado);
    }
}

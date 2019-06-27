using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.RabbitManager
{
    public interface ISender
    {
        void Enviar(string nomeFila, AbstractComportamento comportamento);
    }
}

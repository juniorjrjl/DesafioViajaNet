using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.RabbitManager
{
    public interface IReceiver<T> where T : AbstractComportamento
    {
        T Receber(string nomeFila);
    }
}

using DesafioViajaNet.RabbitManager;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Robo.RabbitReceiver
{
    public class HomeComportamentoReceiver : Receiver<HomeComportamentoDTO>
    {
        public HomeComportamentoReceiver(string hostName) : base(hostName){ }
    }
}

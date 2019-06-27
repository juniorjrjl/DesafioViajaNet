using DesafioViajaNet.RabbitManager;
using DesafioViajaNet.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Robo.RabbitReceiver
{
    public class LandingComportamentoReceiver : Receiver<LandingComportamentoDTO>
    {
        public LandingComportamentoReceiver(string hostName) : base(hostName) { }
    }
}

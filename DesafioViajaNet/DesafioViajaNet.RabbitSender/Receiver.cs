using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.RabbitManager
{
    public abstract class Receiver<T> : IReceiver<T> where T : AbstractComportamento
    {

        private readonly string _hostName;

        public Receiver(string hostName) => _hostName = hostName;

        public T Receber(string nomeFila)
        {
            BasicGetResult data;
            ConnectionFactory factory = new ConnectionFactory() { HostName = _hostName };
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    data = channel.BasicGet(nomeFila, true);
                }
            }
            return data != null ? JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data.Body)) : null;
        }
    }
}

using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.RabbitManager
{
    public class Sender : ISender
    {
        private readonly string _hostName;

        public Sender(string hostName) => _hostName = hostName;

        public void Enviar(string nomeFila, AbstractComportamento comportamento)
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = _hostName };
            using (IConnection connection = factory.CreateConnection())
            {
                using(IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: nomeFila, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    byte[] corpo = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(comportamento));
                    channel.BasicPublish(exchange: string.Empty, routingKey: nomeFila, basicProperties: null, body: corpo);
                }
            }
        }
    }
}

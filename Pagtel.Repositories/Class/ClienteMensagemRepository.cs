using Pagtel.Models.Entities;
using Pagtel.Repositories.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pagtel.Repositories.Class
{
    public class ClienteMensagemRepository : IClienteRepository
    {
        public void EnviaMensagem(ClienteMensagem mensagem)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "leonardo",
                Password = "Leo@347141"

            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Cliente",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(mensagem);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "Cliente",
                                     basicProperties: null,
                                     body: body);

            }
        }

        public void TrazCliente(ClienteMensagem mensagem)
        {
            throw new NotImplementedException();
        }
    }
}

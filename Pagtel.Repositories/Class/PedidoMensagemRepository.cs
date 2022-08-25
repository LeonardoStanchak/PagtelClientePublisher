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
    public class PedidoMensagemRepository : IPedidoRepository
    {
        public void EnviaMensagem(PedidoMensagem pedido)
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
                channel.QueueDeclare(queue: "Pedido",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(pedido);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "Pedido",
                                     basicProperties: null,
                                     body: body);

            }
        }
    }
}

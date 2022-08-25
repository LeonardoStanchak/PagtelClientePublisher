using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Data;

using PedidoConsumer.Domain;
using Pagtel.Models.Entities;

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

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        try
        {
            var body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);

            PedidoMensagem mensagem = JsonSerializer.Deserialize<PedidoMensagem>(message);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

            Pedido pedido = new(mensagem.NumeroPedido, mensagem.DataPedido, mensagem.ClienteID, mensagem.ProdutoId);

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine($"NumeroPedido {mensagem.NumeroPedido}; NumeroPedido {mensagem.DataPedido};", message);

        }
        catch (Exception e)
        {
            channel.BasicNack(deliveryTag: ea.DeliveryTag, false, true);
            throw e;
        }
    };
    channel.BasicConsume(queue: "Pedido",
                         autoAck: false,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}


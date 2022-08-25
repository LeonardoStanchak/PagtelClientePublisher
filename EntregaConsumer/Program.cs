using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Data;

using Pagtel.Models.Entities;
using EntregaConsumer.Domain;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "leonardo",
    Password = "Leo@347141"
};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "Entrega",
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

            EntregaMensagem mensagem = JsonSerializer.Deserialize<EntregaMensagem>(message);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

            Entrega entrega = new(mensagem.Status, mensagem.DataEntrega, mensagem.PedidoID);

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine($"NumeroPedido {mensagem.Status}; NumeroPedido {mensagem.DataEntrega};", message);

        }
        catch (Exception e)
        {
            channel.BasicNack(deliveryTag: ea.DeliveryTag, false, true);
            throw e;
        }
    };
    channel.BasicConsume(queue: "Entrega",
                         autoAck: false,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}


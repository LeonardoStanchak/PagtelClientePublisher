using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Data;
using Pagtel.Models.Entities;
using ProdutoConsumer.Domain;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "leonardo",
    Password = "Leo@347141"
};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "Produto",
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

            ProdutoMensagem mensagem = JsonSerializer.Deserialize<ProdutoMensagem>(message);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

            Produto produto = new(mensagem.NomeProduto, mensagem.Preco);

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine($"NomeProduto {mensagem.NomeProduto}; Preco {mensagem.Preco};", message);

        }
        catch (Exception e)
        {
            channel.BasicNack(deliveryTag: ea.DeliveryTag, false, true);
            throw e;
        }
    };
    channel.BasicConsume(queue: "Produto",
                         autoAck: false,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}


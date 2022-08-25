using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Pagtel.Models;
using Pagtel.Models.Entities;
using System.Text.Json;
using System.Data;
using PagtelConsumer.Domain;

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

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        try
        {
            var body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);

            ClienteMensagem mensagem = JsonSerializer.Deserialize<ClienteMensagem>(message);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

            Cliente cliente = new(mensagem.Nome, mensagem.Cpf, mensagem.DataNascimento, mensagem.Cep,mensagem.Endereco, mensagem.NumeroEndereco, mensagem.Complemento, mensagem.Referencia
                 );
            
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine($"Nome {mensagem.Endereco}; Cpf {mensagem.Cpf}; DataNascimento {mensagem.DataNascimento}; Cep {mensagem.Cep};", message);

        }catch (Exception e)
        {
            channel.BasicNack(deliveryTag: ea.DeliveryTag, false, true);
            throw e;
        }
    };
    channel.BasicConsume(queue: "Cliente",
                         autoAck: false,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}


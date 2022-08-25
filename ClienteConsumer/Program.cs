using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Pagtel.Models;
using Pagtel.Models.Entities;
using System.Text.Json;

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
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        ClienteMensagem mensagem = JsonSerializer.Deserialize<ClienteMensagem>(message);
        

        Console.WriteLine($"Nome: {mensagem.Nome}; Cpf:{mensagem.Cpf}; DataNascimento {mensagem.DataNascimento}; Cep{mensagem.Cep}; Endereco {mensagem.Endereco}");
    };
    channel.BasicConsume(queue: "Cliente",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}


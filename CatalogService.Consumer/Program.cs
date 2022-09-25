using System.Text;
using System.Text.Json;
using CatalogService.Consumer.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


// var configuration =  new ConfigurationBuilder()
//      .SetBasePath(Directory.GetCurrentDirectory())
//      .AddJsonFile($"appsettings.json");

// var config = configuration.Build();


// ServiceProvider serviceProvider = new ServiceCollection()
//     .AddTransient<IEmailService, EmailService>()
//     .BuildServiceProvider();

ProductContext context = new();
var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "123456" };
using (IConnection connection = factory.CreateConnection())

using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "Products",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var product = JsonSerializer.Deserialize<Products>(message);
        context.Send(product);
        // Console.WriteLine(" [x] Received {0}", message);
    };
    channel.BasicConsume(queue: "Products",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}

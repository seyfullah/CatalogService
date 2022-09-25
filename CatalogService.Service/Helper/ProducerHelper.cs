using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using CatalogService.Service.Model;

namespace CatalogService.Helper
{
    public class ProducerHelper
    {
        public static void NotifyForNewProduct(Products model)
        {
            //RabbitMQ bağlantısı için
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "123456" };
            //Channel yaratmak için
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                //Kuyruk oluşturma
                channel.QueueDeclare(queue: "Products",
                    durable: false, //Data fiziksel olarak mı yoksa memoryde mi tutulsun
                    exclusive: false, //Başka connectionlarda bu kuyruğa ulaşabilsin mi
                    autoDelete: false, //Eğer kuyruktaki son mesaj ulaştığında kuyruğun silinmesini istiyorsak kullanılır.
                    arguments: null);//Exchangelere verilecek olan parametreler tanımlamak için kullanılır.

                string message = JsonSerializer.Serialize(model);
                var body = Encoding.UTF8.GetBytes(message);

                //Queue ya atmak için kullanılır.
                channel.BasicPublish(exchange: "",//mesajın alınıp bir veya birden fazla queue ya konmasını sağlıyor.
                    routingKey: "Products", //Hangi queue ya atanacak.
                    body: body);//Mesajun içeriği
            }
        }
    }
}
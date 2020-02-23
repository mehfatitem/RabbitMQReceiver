using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqReceiverProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqReceiverProject.Control
{
    public class RabbitMqConnection
    {
        private ConnectionFactory connectionFactory;
        private ConnectionModel conModel;
        private readonly string connectionPath = "C://Users/MONSTER/source/repos/RabbitMqSenderProject/RabbitMqSenderProject/Data/connection.json";


        public RabbitMqConnection()
        {

            StreamReader streamReader = new StreamReader(connectionPath, Encoding.Default, false);

            string connectionJson = streamReader.ReadToEnd();

            conModel = JsonConvert.DeserializeObject<ConnectionModel>(connectionJson);
            connectionFactory = new ConnectionFactory() { HostName = conModel.HostName, UserName = conModel.UserName, Password = conModel.Password };
        }

        public IConnection OpenRabbitConnection()
        {

            IConnection connection = connectionFactory.CreateConnection();
            return connection;
        }

        public void ReceiveMessageFromQuery(string queue, bool autoAck = true , bool durable = false, bool exclusive = false, IDictionary<string, object> arguments = null)
        {
            var connection = OpenRabbitConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(queue: queue, durable: durable, exclusive: exclusive, arguments: arguments);

     

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, eventArg) =>
            {
                var body = eventArg.Body;
                var message = Encoding.UTF8.GetString(body);
                Person person = JsonConvert.DeserializeObject<Person>(message);
                Console.WriteLine($" Adı: {person.Name} Soyadı:{person.SurName} [{person.Message}] Mesaj Gonderim Zamani : {person.MessageSendTime} Mesaj Okuma Zamani : {DateTime.Now}" );
            };
            channel.BasicConsume(queue: queue, autoAck: autoAck, consumer: consumer);

            Console.WriteLine("Mesaj alimistir :)");
            Console.ReadLine();

            Console.ReadLine();

        }
    }
}

using RabbitMqReceiverProject.Control;
using RabbitMqReceiverProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqReceiverProject
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMqConnection rmqConnection = new RabbitMqConnection();
            rmqConnection.ReceiveMessageFromQuery("fatihinAnahtari");
        }
    }
}

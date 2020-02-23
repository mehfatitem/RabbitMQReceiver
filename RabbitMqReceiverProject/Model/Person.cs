using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqReceiverProject.Model
{
    public class Person
    {
        private int id;
        private string name;
        private string surName;
        private DateTime birthDate;
        private string message;
        private DateTime messageSendTime;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string SurName { get => surName; set => surName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Message { get => message; set => message = value; }
        public DateTime MessageSendTime { get => messageSendTime; set => messageSendTime = value; }
    }
}

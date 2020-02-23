using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqReceiverProject.Model
{
    public class ConnectionModel
    {
        private string hostName;
        private string userName;
        private string password;
        private string jsonPath;


        public string HostName { get => hostName; set => hostName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string JsonPath { get => jsonPath; set => jsonPath = value; }
    }
}

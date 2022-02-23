using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace WpfAppB.Models
{
    class RecieveMessage
    {
        public string connectionString;

        public string queueName;

        public ServiceBusClient client;

        public ServiceBusProcessor processor;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.Configuration;
using MassTransit;
using MassTransit.AzureServiceBusTransport;
using System.Configuration;

namespace Masstransit
{
    public class EmailQueueEndpoint
    {
        private IBus _transport;
        private Uri Uri;
        private ISendEndpoint Endpoint;
        private string ConnectionString;
        private string Queuename;
        public EmailQueueEndpoint(IBus transport)
        {
            _transport = transport;
        }
        public async Task InitializeAsync()
        {
            ConnectionString = Constants.ConnectionString;
            Queuename = Constants.QueueName;
            Uri = new Uri(ConnectionString + Queuename);
            Endpoint = await _transport.GetSendEndpoint(Uri);
        }

        public Task Send(EmailMessage message)
        {
            return Endpoint.Send<EmailMessage>(message);
        }
    }
}

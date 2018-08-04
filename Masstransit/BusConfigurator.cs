using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.AzureServiceBusTransport;
using Microsoft.ServiceBus;

namespace Masstransit
{
    public static class BusConfigurator
    {
        private static string ConnectionString;
        private static string KeyName;
        private static string SharedAccessKey;

        public static IBus ConfigureBus()
        {
            ConnectionString = Constants.ConnectionString;
            KeyName = Constants.KeyName;
            SharedAccessKey = Constants.SharedAccessKey;

            var busControl = Bus.Factory.CreateUsingAzureServiceBus(x =>
            {
                var host = x.Host(ConnectionString, h =>
                {
                    h.SharedAccessSignature(s =>
                    {
                        s.KeyName = KeyName;
                        s.SharedAccessKey = SharedAccessKey;
                        s.TokenTimeToLive = TimeSpan.FromDays(1);
                        s.TokenScope = TokenScope.Namespace;
                    });
                });
            });
            return busControl;
        }
    }
}

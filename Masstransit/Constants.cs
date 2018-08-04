using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masstransit
{
    public static class Constants
    {
        public const string ConnectionString = "sb://emailservicenamespace.servicebus.windows.net/";
        public const string KeyName = "RootManageSharedAccessKey";
        public const string SharedAccessKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        public const string QueueName = "emailqueue";
    }
}

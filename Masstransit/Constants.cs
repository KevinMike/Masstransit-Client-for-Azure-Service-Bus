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
        public const string SharedAccessKey = "e8INJF1q5NA9weBZVbUZFC7nOpv0D8cPaZUJ+xTztJM=";
        public const string QueueName = "emailqueue";
    }
}

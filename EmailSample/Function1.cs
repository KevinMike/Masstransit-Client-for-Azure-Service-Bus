using System;
using Microsoft.Azure.KeyVault.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace EmailSample
{
    public static class Function1
    {
        [FunctionName("EmailSender")]
        public static void Run([QueueTrigger("request", Connection = "")]string myQueueItem, TraceWriter log)
        {
            
        }

           [FunctionName("SendEmail")]
        public static void Run(
        [ServiceBusTrigger("myqueue", Connection = "ServiceBusConnection")] OutgoingEmail email,
        [SendGrid(IKey = "CustomSendGridKeyAppSettingName")] out SendGridMessage message)
        {
            message = new SendGridMessage();
            message.AddTo(email.To);
            message.AddContent("text/html", email.Body);
            message.SetFrom(new EmailAddress(email.From));
            message.SetSubject(email.Subject);
        }

        public class OutgoingEmail
        {
            public string To { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }
    }
}

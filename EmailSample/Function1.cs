using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;

namespace EmailSample
{
    public static class Function1
    {
        [FunctionName("SendEmail")]
        public static void Run(TraceWriter log,
        [ServiceBusTrigger("emailqueue", Connection = "ServiceBusConnection")] OutgoingEmail email,
        [SendGrid(ApiKey = "SengridApiKey")] out SendGridMessage message)
        {
            log.Info($"Request incoming{email.ToString()}");
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
            public string From { get; set; }
        }
    }
}

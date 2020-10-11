using Autofac;
using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Email.Interfaces;
using Quiplogs.Notifications.Send;
using Quiplogs.Notifications.Send.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Notifications.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new SendNotificationModule(Configuration));
            var container = builder.Build();

            var tags = new Dictionary<string, string>();
            tags.Add("firstName", "Jonathan");

            var email = new TestMail
            {
                TemplateId = "12345667",
                FromEmailAddress = "test@from.com",
                FromName = "Busy Dev",
                ToEmailAddress = "test.to.com",
                ToName = "Another Busy Dev",
                ReplacementTags = tags
            };

            var emailService = container.Resolve<IEmailService>();
            emailService.Process(email);
        }
    }

    public class TestMail : IEmail
    {
        public string TemplateId { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromName { get; set; }
        public string ToEmailAddress { get; set; }
        public string ToName { get; set; }
        public Dictionary<string, string> ReplacementTags { get; set; }
    }
}

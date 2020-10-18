using Autofac;
using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Email.Models;
using Quiplogs.Notifications.Process;
using Quiplogs.Notifications.Process.Interfaces;
using Quiplogs.Notifications.Send;
using Quiplogs.Notifications.Send.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Notifications.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Send

            //IConfiguration Configuration = new ConfigurationBuilder()
            //   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //   .Build();

            //var builder = new ContainerBuilder();
            //builder.RegisterModule(new SendNotificationModule(Configuration));
            //var container = builder.Build();

            //var tags = new Dictionary<string, string>();
            //tags.Add("first_name", "Jonathan");
            //tags.Add("last_name", "Meyer");
            //tags.Add("company", "Quiplogs");

            //var email = new EmailWithTemplate
            //{
            //    TemplateId = "d-e6e65211e3814c3890b05d30d14916a2",
            //    FromEmailAddress = "jonathan@quiplogs.com",
            //    FromName = "Quiplogs",
            //    ToEmailAddress = "jcmeyer@outlook.com",
            //    ToName = "Jonathan",
            //    Subject = "Success Test",
            //    ReplacementTags = tags
            //};

            //var emailService = container.Resolve<ISendService>();
            //emailService.SendNotification(email);

            //Test Process

            var builder = new ContainerBuilder();
            builder.RegisterModule(new ProcessNotificationModule());
            var container = builder.Build();

            var twilioService = container.Resolve<ISendGridService>();
            twilioService.SendMail("eB/37AUx6Tpu+Iz20LHGUZAcfq7urhbYe/mZSx+ywpwNdoGyPTqDhK33x1nM1yCkiogJ4zmNayRbJ+WGktwt5YzDPb0Fxgo9zIme4KhOFtxfqvPH6O4NKeSMutem2zm/NLRIIok6g95V/qO+ThxFqNrjWj+2lxLeliCFgozWtPUrnz91ClvOEywTwQ1DjqukK5Z/dGB1BG5j3cixqrhIFRjpKyPIvxqWKf/rQ+mbW0l5qCnVZ2fhhw5li1jTOEOIDOVOHxSw7ovSoObD4jKEE4LntvERfwIOez2yu3QxUjU+GaHH1DR9y2KS7IP9bpD1U42PeBqhN3OlBaDFkKoVQYH38zMvpDz/iNA9JYUsNDLOhLRK2u9X6cqkYxNFEozf");
        }
    }
}

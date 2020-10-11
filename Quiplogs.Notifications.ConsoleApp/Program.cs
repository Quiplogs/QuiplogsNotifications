using Autofac;
using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Send;
using Quiplogs.Notifications.Send.Interfaces;

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

            var emailService = container.Resolve<IEmailService>();
            emailService.Process();
        }
    }
}

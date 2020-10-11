using Autofac;
using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Queue;
using Quiplogs.Notifications.Send.Interfaces;
using Quiplogs.Notifications.Send.Services;

namespace Quiplogs.Notifications.Send
{
    public class SendNotificationModule : Module
    {
        private readonly IConfiguration configuration;

        public SendNotificationModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailService>()
                .As<IEmailService>()
                .WithParameter(new TypedParameter(typeof(IConfiguration), this.configuration));

            builder.RegisterModule(new QueueModule(this.configuration));
        }
    }
}

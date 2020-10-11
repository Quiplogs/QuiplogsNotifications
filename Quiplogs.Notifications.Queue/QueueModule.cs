using Autofac;
using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Queue.Interfaces;
using Quiplogs.Notifications.Queue.Services;

namespace Quiplogs.Notifications.Queue
{
    public class QueueModule : Module
    {
        private readonly IConfiguration configuration;

        public QueueModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AzureQueueService>()
                .As<IAzureQueueService>()
                .WithParameter(new TypedParameter(typeof(IConfiguration), this.configuration));
        }
    }
}

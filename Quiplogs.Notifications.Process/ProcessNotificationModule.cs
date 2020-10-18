using Autofac;
using Quiplogs.Notifications.Process.Interfaces;
using Quiplogs.Notifications.Process.Services;

namespace Quiplogs.Notifications.Process
{
    public class ProcessNotificationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SendGridService>().As<ISendGridService>();
            builder.RegisterType<CheckConfigurationService>().As<ICheckConfigurationService>();
        }
    }
}

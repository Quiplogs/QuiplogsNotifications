using Autofac;
using AzureFunctions.Autofac.Configuration;
using Quiplogs.Notifications.Process.Interfaces;
using Quiplogs.Notifications.Process.Services;

namespace Quiplogs.Notifications.Process
{
    public class ProcessNotificationModule
    {
        public ProcessNotificationModule(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<SendGridService>().As<ISendGridService>();
                builder.RegisterType<CheckConfigurationService>().As<ICheckConfigurationService>();

            }, functionName);
        }
    }
}

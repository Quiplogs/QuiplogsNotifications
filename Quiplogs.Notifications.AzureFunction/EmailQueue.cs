using AzureFunctions.Autofac;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Quiplogs.Notifications.Process;
using Quiplogs.Notifications.Process.Interfaces;

namespace Quiplogs.Notifications.AzureFunction
{
    [DependencyInjectionConfig(typeof(ProcessNotificationModule))]
    public static class EmailQueue
    {
        [FunctionName("EmailQueueFunction")]
        public static void Run([QueueTrigger("queue_name", Connection = "AzureWebJobsStorage")]byte[] encryptedMail, [Inject] ISendGridService sendGridService, ILogger log)
        {
            sendGridService.SendMail(encryptedMail);
            log.LogInformation($"Emailed sent");
        }
    }
}

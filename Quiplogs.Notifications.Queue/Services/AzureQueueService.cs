using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Queue.Interfaces;
using Quiplogs.Notifications.Utilities.Configuration;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Notifications.Queue.Services
{
    public class AzureQueueService : IAzureQueueService
    {
        private readonly AzureQueueConfiguration _azureConfiguration;

        public AzureQueueService(IConfiguration configuration)
        {
            var config = configuration.GetSection("AppSettings:QuiplogsNotifications:Azure").Get<AzureQueueConfiguration>();

            if (config == null)
                throw new Exception("No Azure configuration was found");
            else
                _azureConfiguration = config;
        }

        public async Task Put(string message)
        {
            try
            {
                QueueClient queueClient = new QueueClient(_azureConfiguration.DataConnectionString, _azureConfiguration.EmailQueueName);

                queueClient.CreateIfNotExists();

                if (queueClient.Exists())
                {
                    await queueClient.SendMessageAsync(message);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

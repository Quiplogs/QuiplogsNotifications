using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using Quiplogs.Notifications.Queue.Interfaces;
using Quiplogs.Notifications.Utilities.Configuration;
using System;

namespace Quiplogs.Notifications.Queue.Services
{
    public class AzureQueueService : IAzureQueueService
    {
        private IConfiguration _configuration;

        public AzureQueueService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void Put(string message)
        {
            try
            {
                var config = _configuration.GetSection("AppSettings:QuiplogsNotifications:Azure").Get<AzureQueue>();
                QueueClient queueClient = new QueueClient(config.DataConnectionString, config.EmailQueueName);

                queueClient.CreateIfNotExists();

                if (queueClient.Exists())
                {
                    await queueClient.SendMessageAsync(message);
                }
            }
            catch (Exception ex)
            {
                //log exception
            }
        }
    }
}

using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Queue.Interfaces;
using Quiplogs.Notifications.Queue.Models;
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

        public void Put()
        {
            try
            {
                // Get the connection string from app settings
                var config = _configuration.GetSection("AppSettings:QuiplogsNotifications:Send").Get<QueueConfiguration>();

                // Instantiate a QueueClient which will be used to create and manipulate the queue
                QueueClient queueClient = new QueueClient(config.DataConnectionString, "emailQueue");

                // Create the queue
                queueClient.CreateIfNotExists();

                if (queueClient.Exists())
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

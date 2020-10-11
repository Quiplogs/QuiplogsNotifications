using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Quiplogs.Notifications.Email.Interfaces;
using Quiplogs.Notifications.Queue.Interfaces;
using Quiplogs.Notifications.Send.Interfaces;
using Quiplogs.Notifications.Utilities.Configuration;
using Quiplogs.Notifications.Utilities.Security;
using System;

namespace Quiplogs.Notifications.Send.Services
{
    public class EmailService : IEmailService
    {
        private IAzureQueueService _azureQueueService;
        private IConfiguration _configuration;

        public EmailService(IAzureQueueService azureQueueService, IConfiguration configuration)
        {
            _azureQueueService = azureQueueService;
            _configuration = configuration;
        }

        public void Process(IEmail email)
        {
            //serialize email
            var serializedEmail = JsonConvert.SerializeObject(email);

            //encrypt email
            var config = _configuration.GetSection("AppSettings:QuiplogsNotifications:Security").Get<Security>();

            if (config == null || string.IsNullOrWhiteSpace(config.Key))
                throw new Exception("No security key has been set");

            var encryptedText = Encryption.EncryptString(config.Key, serializedEmail);

            //send email
            _azureQueueService.Put(encryptedText);
        }
    }
}

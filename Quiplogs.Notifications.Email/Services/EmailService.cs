using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Email.Interfaces;
using Quiplogs.Notifications.Queue.Interfaces;
using Quiplogs.Notifications.Send.Interfaces;
using Quiplogs.Notifications.Utilities.Configuration;
using Quiplogs.Notifications.Utilities.Security;

namespace Quiplogs.Notifications.Send.Services
{
    public class EmailService : IEmailService
    {
        private readonly IAzureQueueService _azureQueueService;
        private readonly SecurityConfiguration _securityConfig;

        public EmailService(IAzureQueueService azureQueueService, IConfiguration configuration)
        {
            _azureQueueService = azureQueueService;

            var config = configuration.GetSection("AppSettings:QuiplogsNotifications:Security").Get<SecurityConfiguration>();

            if (config == null || string.IsNullOrWhiteSpace(config.Key))
                throw new Exception("No security key has been set");
            else
                _securityConfig = config;
        }

        public async Task AddEmailToQueueAsync(IEmail email)
        {
            //serialize email
            var serializedEmail = JsonConvert.SerializeObject(email);

            //encrypt email
            var encryptedText = Encryption.EncryptString(_securityConfig.Key, serializedEmail);

            //send email to azure queue
            try
            {
                await _azureQueueService.Put(encryptedText);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

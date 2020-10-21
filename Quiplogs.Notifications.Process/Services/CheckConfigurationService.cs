using Quiplogs.Notifications.Process.Interfaces;
using Quiplogs.Notifications.Process.Models;
using System;

namespace Quiplogs.Notifications.Process.Services
{
    public class CheckConfigurationService : ICheckConfigurationService
    {
        public SendGridConfiguration CheckConfigurtionVariables()
        {
            var sendGridConfiguration = new SendGridConfiguration();

            if (string.IsNullOrWhiteSpace(sendGridConfiguration.APIKey))
                throw new Exception("No Twilio SendGrid API Key has been set.");

            if (string.IsNullOrWhiteSpace(sendGridConfiguration.SecurityKey))
                throw new Exception("No Decryption key has been set.");

            return sendGridConfiguration;
        }
    }
}

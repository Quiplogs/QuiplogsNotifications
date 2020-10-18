using Quiplogs.Notifications.Process.Interfaces;
using Quiplogs.Notifications.Process.Models;
using System;

namespace Quiplogs.Notifications.Process.Services
{
    public class CheckConfigurationService : ICheckConfigurationService
    {
        public SendGridConfiguration CheckConfigurtionVariables()
        {
            var twilioConfiguration = new SendGridConfiguration();

            if (string.IsNullOrWhiteSpace(twilioConfiguration.APIKey))
                throw new Exception("No Twilio SendGrid API Key has been set.");

            if (string.IsNullOrWhiteSpace(twilioConfiguration.SecurityKey))
                throw new Exception("No Decryption key has been set.");

            return twilioConfiguration;
        }
    }
}

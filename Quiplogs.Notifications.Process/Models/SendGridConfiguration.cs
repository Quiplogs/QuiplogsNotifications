using System;

namespace Quiplogs.Notifications.Process.Models
{
    public class SendGridConfiguration
    {
        public string APIKey { get => Environment.GetEnvironmentVariable("SENDGRID_API_KEY"); }

        public string SecurityKey { get => Environment.GetEnvironmentVariable("SECURITY_KEY"); }
    }
}

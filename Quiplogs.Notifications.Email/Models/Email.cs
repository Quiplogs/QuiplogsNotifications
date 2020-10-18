using Quiplogs.Notifications.Email.Interfaces;

namespace Quiplogs.Notifications.Email.Models
{
    public class Email : IEmail
    {
        public string Subject { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromName { get; set; }
        public string ToEmailAddress { get; set; }
        public string ToName { get; set; }
    }
}

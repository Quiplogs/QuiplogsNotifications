using System.Collections.Generic;

namespace Quiplogs.Notifications.Email.Interfaces
{
    public interface IEmail
    {
        public string TemplateId { get; set; }
        public string From { get; set; }
        public string FromUserName { get; set; }
        public string To { get; set; }
        public string ToUserName { get; set; }
        Dictionary<string, string> ReplacementTags { get; set; }
    }
}

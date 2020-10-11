using System.Collections.Generic;

namespace Quiplogs.Notifications.Email.Interfaces
{
    public interface IEmail
    {
        public string TemplateId { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromName { get; set; }
        public string ToEmailAddress { get; set; }
        public string ToName { get; set; }
        Dictionary<string, string> ReplacementTags { get; set; }
    }
}

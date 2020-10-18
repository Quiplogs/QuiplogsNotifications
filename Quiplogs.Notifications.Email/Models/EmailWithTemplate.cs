using System.Collections.Generic;

namespace Quiplogs.Notifications.Email.Models
{
    public class EmailWithTemplate : Email
    {
        public string TemplateId { get; set; }
        public Dictionary<string, string> ReplacementTags { get; set; }
    }
}

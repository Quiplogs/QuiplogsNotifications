namespace Quiplogs.Notifications.Email.Models
{
    public class EmailPlain : Email
    {
        public string HTMLContent { get; set; }

        public string PlainContent { get; set; }
    }
}

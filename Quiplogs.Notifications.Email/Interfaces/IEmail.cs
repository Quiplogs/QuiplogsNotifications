namespace Quiplogs.Notifications.Email.Interfaces
{
    public interface IEmail
    {
        string Subject { get; set; }
        string FromEmailAddress { get; set; }
        string FromName { get; set; }
        string ToEmailAddress { get; set; }
        string ToName { get; set; }        
    }
}

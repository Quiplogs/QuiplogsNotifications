using Quiplogs.Notifications.Email.Interfaces;

namespace Quiplogs.Notifications.Send.Interfaces
{
    public interface IEmailService
    {
        void Process(IEmail email);
    }
}

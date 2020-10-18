using Quiplogs.Notifications.Email.Interfaces;
using System.Threading.Tasks;

namespace Quiplogs.Notifications.Send.Interfaces
{
    public interface IEmailService
    {
        Task AddEmailToQueueAsync(IEmail email);
    }
}

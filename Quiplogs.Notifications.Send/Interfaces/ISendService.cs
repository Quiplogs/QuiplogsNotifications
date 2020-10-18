using Quiplogs.Notifications.Email.Interfaces;
using System.Threading.Tasks;

namespace Quiplogs.Notifications.Send.Interfaces
{
    public interface ISendService
    {
        Task SendNotification(IEmail email);
    }
}

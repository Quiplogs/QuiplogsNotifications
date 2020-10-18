using Quiplogs.Notifications.Email.Interfaces;
using System.Threading.Tasks;

namespace Quiplogs.Notifications.Process.Interfaces
{
    public interface ISendGridService
    {
        Task SendMail(string queueMessage);
    }
}

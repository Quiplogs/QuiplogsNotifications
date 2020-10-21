using System.Threading.Tasks;

namespace Quiplogs.Notifications.Process.Interfaces
{
    public interface ISendGridService
    {
        Task SendMail(byte[] queueMessage);
    }
}

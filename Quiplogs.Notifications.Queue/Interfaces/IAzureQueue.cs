using System.Threading.Tasks;

namespace Quiplogs.Notifications.Queue.Interfaces
{
    public interface IAzureQueueService
    {
        Task Put(string message);
    }
}

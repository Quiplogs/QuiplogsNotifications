using Quiplogs.Notifications.Process.Models;

namespace Quiplogs.Notifications.Process.Interfaces
{
    public interface ICheckConfigurationService
    {
        SendGridConfiguration CheckConfigurtionVariables();
    }
}

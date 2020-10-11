using Quiplogs.Notifications.Queue.Interfaces;
using Quiplogs.Notifications.Send.Interfaces;

namespace Quiplogs.Notifications.Send.Services
{
    public class EmailService : IEmailService
    {
        private IAzureQueueService _azureQueueService;

        public EmailService(IAzureQueueService azureQueueService)
        {
            _azureQueueService = azureQueueService;
        }

        public void Process()
        {
            _azureQueueService.Put();
        }
    }
}

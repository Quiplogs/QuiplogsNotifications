using Quiplogs.Notifications.Email.Interfaces;
using Quiplogs.Notifications.Send.Interfaces;
using System.Threading.Tasks;

namespace Quiplogs.Notifications.Send.Services
{
    public class SendService : ISendService
    {
        private readonly IEmailService _emailService;

        public SendService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// Adds and Email onto the Email Azure Queue
        /// </summary>
        /// <param name="email"></param>
        public async Task SendNotification(IEmail email)
        {
            await _emailService.AddEmailToQueueAsync(email);
        }
    }
}

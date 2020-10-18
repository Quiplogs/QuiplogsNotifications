using Newtonsoft.Json;
using Quiplogs.Notifications.Email.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Quiplogs.Notifications.Process.Interfaces;
using Quiplogs.Notifications.Process.Models;
using Quiplogs.Notifications.Utilities.Security;

namespace Quiplogs.Notifications.Process.Services
{
    public class SendGridService : ISendGridService
    {
        private readonly SendGridClient _sendGridClient;
        private readonly ICheckConfigurationService _checkConfigurationService;
        private readonly SendGridConfiguration _twilioConfiguration;

        public SendGridService(ICheckConfigurationService checkConfigurationService)
        {
            _checkConfigurationService = checkConfigurationService;
            _twilioConfiguration = _checkConfigurationService.CheckConfigurtionVariables();

            _sendGridClient = new SendGridClient(_twilioConfiguration.APIKey);
        }

        public async Task SendMail(string queueMessage)
        {
            //Decrypt email
            var decryptedMail = Decryption.DecryptString(_twilioConfiguration.SecurityKey, queueMessage);

            var sendGridMessage = new SendGridMessage();

            var _templateEmail = JsonConvert.DeserializeObject<EmailWithTemplate>(decryptedMail);
            if (!string.IsNullOrWhiteSpace(_templateEmail.TemplateId))
            {
                sendGridMessage.SetFrom(new EmailAddress(_templateEmail.FromEmailAddress, _templateEmail.FromName));
                sendGridMessage.AddTo(new EmailAddress(_templateEmail.ToEmailAddress, _templateEmail.ToName));
                sendGridMessage.SetTemplateId(_templateEmail.TemplateId);
                sendGridMessage.SetSubject(_templateEmail.Subject);
                sendGridMessage.SetTemplateData(_templateEmail.ReplacementTags);
            }

            var _plainEmail = JsonConvert.DeserializeObject<EmailPlain>(decryptedMail);
            if (!string.IsNullOrWhiteSpace(_plainEmail.HTMLContent) || !string.IsNullOrWhiteSpace(_plainEmail.PlainContent))
            {
                sendGridMessage = MailHelper.CreateSingleEmail(new EmailAddress(_plainEmail.FromEmailAddress, _plainEmail.FromName), new EmailAddress(_plainEmail.ToEmailAddress, _plainEmail.ToName), _plainEmail.Subject, _plainEmail.PlainContent, _plainEmail.HTMLContent);
            }

            await _sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}

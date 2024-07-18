
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace W7.D3.BusinessLayer.MailServices
{
    public class SendGridMailService : IMailService
    {
        private readonly string apiKey;
        public SendGridMailService(IConfiguration config)
        {
            apiKey = config["SendGrid"]!.ToString();
        }

        public void SendMail(string to, string subject, string body)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("nellorizzo@live.it", "[My Web App]");
            var plainTextContent = body;
            var htmlContent = $"<strong>{body}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, new EmailAddress(to),
                subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg).Result;
        }
    }
}

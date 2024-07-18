using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace W7.D3.BusinessLayer
{
    public class DotNetMailService : IMailService
    {
        public void SendMail(string to, string subject, string body) {
            using var client = new SmtpClient {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("nello.rizzo.test@gmail.com", "r1zz0nell0")
            };
            using var msg = new MailMessage { 
                From = new MailAddress("nello.rizzo.test@gmail.com", "[My Web App] - Mail Sender"), 
                Subject = subject, 
                Body = body 
            };
            msg.To.Add(to);
            client.Send(msg);
        }
    }
}

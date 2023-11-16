using System.Net.Mail;
using System.Net;

namespace PizzaBookingAppServer.Helpers
{
    public interface IMailService
    {
        void SendMail(IEnumerable<string> to, string subject, string content, bool isBodyHtml = false);
    }

    public class MailService : IMailService
    {
        private SmtpClient smtpClient;
        public MailService()
        {
            smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.Port = 587; // Port của SMTP server
            smtpClient.Credentials = new NetworkCredential(
                "liemdev23@outlook.com",
                "ThisIsSecret@");
            smtpClient.EnableSsl = true;
        }

        public void SendMail(IEnumerable<string> to, string subject, string content, bool isBodyHtml = false)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("liemdev23@outlook.com");
            foreach (var reciever in to) 
            {
                message.To.Add(reciever);
            }
            message.Subject = subject;
            message.Body = content;
            message.IsBodyHtml = true;

            smtpClient.Send(message);
        }
    }
}

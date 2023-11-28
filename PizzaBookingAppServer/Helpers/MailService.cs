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
        private const string MAIL = "noname281123@outlook.com";
		private const string PASSWORD = "Letmein12#";

		private SmtpClient smtpClient;

        public MailService()
        {
            smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.Port = 587; // Port của SMTP server
            smtpClient.Credentials = new NetworkCredential(MAIL, PASSWORD);
            smtpClient.EnableSsl = true;
        }

        public void SendMail(
            IEnumerable<string> to,
            string subject, 
            string content, 
            bool isBodyHtml = false)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(MAIL);

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

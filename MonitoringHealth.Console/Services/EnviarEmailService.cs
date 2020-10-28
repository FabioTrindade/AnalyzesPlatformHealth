using System.Net;
using System.Net.Mail;

namespace ConsoleEnviarEmail.Services
{
    public class EnviarEmailServices
    {
        private string Smtp { get; set; }
        private string Username { get; set; }
        private string Pasword { get; set; }
        private int Port { get; set; }

        public EnviarEmailServices(string smtp, string username, string password, int port)
        {
            this.Smtp = smtp;
            this.Username = username;
            this.Pasword = password;
            this.Port = port;
        }

        public void Send(string from, string to, string title, string message)
        {
            using (SmtpClient client = new SmtpClient(this.Smtp))
            {
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Port = this.Port;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Credentials = new NetworkCredential(this.Username, this.Pasword);

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from);
                mailMessage.To.Add(to);
                mailMessage.Body = message;
                mailMessage.Subject = title;
                client.Send(mailMessage);
            }
        }
    }
}
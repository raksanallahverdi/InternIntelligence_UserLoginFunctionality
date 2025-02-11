using Business.Utilities.EmailHandler.Abstract;
using Business.Utilities.EmailHandler.Models;
using MimeKit;
using MailKit.Net.Smtp;


namespace Business.Utilities.EmailHandler.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;
        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;

        }
        public void SendMessage(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.UserName));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }
        private void Send(MimeMessage message)
        {
            using(var client= new SmtpClient())
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
                client.Send(message);
            }
        }


    }
}

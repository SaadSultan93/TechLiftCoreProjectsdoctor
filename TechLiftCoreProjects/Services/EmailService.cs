using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using TechLiftCoreProjects.Configuration;
using TechLiftCoreProjects.Models;

namespace TechLiftCoreProjects.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;   
        }
        /// <summary>
        ///  model
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendEmail(EmailMessage msg)
        {

            //// actual code to send email
            ///MimeMessage to subject from email
            ///BodyBuilder--- message body build 
            ///smtp client final class use email send
            ///
            MimeMessage message = new MimeMessage();
            MailboxAddress toadress = new MailboxAddress(msg.ToName, msg.ToEmail);

            MailboxAddress fromEmail = new MailboxAddress(_settings.FromName, _settings.FromEmail);

            message.To.Add(toadress);
            message.From.Add(fromEmail);

            // message.Subject = msg.Subject;
            message.Subject = msg.Subject;

            // message body 

            BodyBuilder builder = new BodyBuilder();
            // builder.TextBody = msg.Body;
            builder.TextBody = msg.Body;
            message.Body = builder.ToMessageBody();

            ///smtp class 
            ///
            var smtp = new SmtpClient();
            smtp.Connect(_settings.Host, _settings.Port,SecureSocketOptions.Auto);
            ///send
            /// real gmail username/// real password
            smtp.Authenticate(_settings.FromEmail, _settings.Password);
            // smtp server connect
           
            smtp.Send(message);
            return true;


        }
    }
}

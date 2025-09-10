
using Microsoft.Extensions.Options;
using PostalService.Config;
using System.Net;
using System.Net.Mail;

namespace PostalService.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_emailSettings.FromEmail);
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using SmtpClient smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
            smtp.Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password);
            smtp.EnableSsl = _emailSettings.EnableSsl;
            await smtp.SendMailAsync(mail);
        }
    }
}

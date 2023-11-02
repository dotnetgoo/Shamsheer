using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Shamsheer.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shamsheer.Service.Interfaces.Emails;

namespace Shamsheer.Service.Services.Emails
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            this._configuration = configuration.GetSection("Email");
        }
        public async Task SendMessageAsync(EmailVerification message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailAddress"]));
            email.To.Add(MailboxAddress.Parse(message.To));

            email.Subject = message.Subject;

            email.Body = new TextPart("html")
            {
                Text = message.Body
            };

            var smtp = new SmtpClient();

            await smtp.ConnectAsync(_configuration["Host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_configuration["EmailAddress"], _configuration["Password"]);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }
}

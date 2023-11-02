using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Shamsheer.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shamsheer.Service.Interfaces.Emails;
using Shamsheer.Service.Exceptions;

namespace Shamsheer.Service.Services.Emails
{
    public class EmailVerificationService : IEmailVerificationService
    {
        private readonly IConfiguration _configuration;
        public EmailVerificationService(IConfiguration configuration)
        {
            this._configuration = configuration.GetSection("Email");
        }
        public async Task SendMessageAsync(EmailVerification message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailAddress"]));

            if (message.To.EndsWith("gmail.com"))
                email.To.Add(MailboxAddress.Parse(message.To));
            else
                throw new ShamsheerException(400, "such an email cannot exist");

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

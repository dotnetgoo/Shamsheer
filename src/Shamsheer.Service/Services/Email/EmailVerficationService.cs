using System;
using System.Collections.Generic;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Shamsheer.Service.Interfaces.Email;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace Shamsheer.Service.Services.Email
{
    public class EmailVerificationService : IEmailVerificationService
    {
        private readonly IConfiguration _configuration;
        private readonly Dictionary<string, string> _userCodes;
        private string _generatedCode;

        
        public EmailVerificationService(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("Email");
            _userCodes = new Dictionary<string, string>();
            _generatedCode = GenerateCode();
        }

        public string GenerateCode()
        {
            Random random = new Random();
            int code = random.Next(10000, 99999);
            return code.ToString();
        }

        public async Task<string> SendMessageAsync(string toEmail)
        {
            string randomCode = _generatedCode;

            _userCodes[toEmail] = randomCode;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailAddress"]));
            email.To.Add(MailboxAddress.Parse(toEmail));

            email.Subject = "Shamsheer";

            email.Body = new TextPart("plain")

            {
                Text = randomCode
            };

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                await smtp.ConnectAsync(_configuration["Host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_configuration["EmailAddress"], _configuration["Password"]);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            return randomCode;
        }
    }
}

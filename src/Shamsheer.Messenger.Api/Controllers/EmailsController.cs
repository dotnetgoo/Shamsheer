using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Entities;
using Shamsheer.Service.Interfaces.Emails;

namespace Shamsheer.Messenger.Api.Controllers
{
        public class EmailsController : BaseController
        {
            private readonly IEmailVerificationService _emailService;
            public EmailsController(IEmailVerificationService emailService)
            {
                _emailService = emailService;
            }
            [HttpPost]
            public async Task<IActionResult> SendMessageAsync(EmailVerification message)
            {
                await _emailService.SendMessageAsync(message);
                return Ok();
            }

        }
}

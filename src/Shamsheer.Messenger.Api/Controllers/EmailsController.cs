using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Entities;
using Shamsheer.Service.Interfaces.Emails;

namespace Shamsheer.Messenger.Api.Controllers
{
        public class EmailsController : BaseController
        {
            private readonly IEmailService _emailService;
            public EmailsController(IEmailService emailService)
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

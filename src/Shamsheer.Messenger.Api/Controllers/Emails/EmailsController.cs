// EmailsController.cs

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shamsheer.Service.Interfaces.Email;

namespace Shamsheer.Messenger.Api.Controllers.Emails
{
    public class EmailsController : BaseController
    {
        private readonly IEmailVerificationService _emailVerificationService;
        private readonly IMemoryCache _cache;

        public EmailsController(IEmailVerificationService emailVerificationService, IMemoryCache cache)
        {
            _emailVerificationService = emailVerificationService;
            _cache = cache;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] string toEmail)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
            {
                return BadRequest("Email is required");
            }

            string sentCode = await _emailVerificationService.SendMessageAsync(toEmail);

            _cache.Set(sentCode, sentCode, TimeSpan.FromMinutes(2));

            return Ok(new { Message = "Email sent successfully" });
        }

        [HttpPost("verify")]
        public IActionResult VerifyCode([FromBody] string codeFromUser)
        {
            var cachedValue = _cache.Get<string>(codeFromUser);

            if (cachedValue is null)
                return BadRequest(new { Error = "Code is invalid" });

            return Ok("code is valid");
        }
    }
}

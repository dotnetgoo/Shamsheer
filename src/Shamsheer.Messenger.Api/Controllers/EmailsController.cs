using Microsoft.AspNetCore.Mvc;
using Shamsheer.Domain.Entities;
using Shamsheer.Service.Interfaces.Emails;

namespace Shamsheer.Messenger.Api.Controllers;
[ApiController]
[Route("api/controller")]

public class EmailsController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailsController(IEmailService emailService)
    {
        _emailService = emailService;
    }
    [HttpPost]
    public async Task<IActionResult> SendMessageAsync(ShamsheerVerification message)
    {
        await _emailService.SendMessage(message);
        return Ok();

    }
}

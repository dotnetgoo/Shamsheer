using Microsoft.AspNetCore.Mvc;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.Interfaces.Users;

namespace Shamsheer.Messenger.Api.Controllers.Users;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]

    public async Task<IActionResult> PostAsync(LoginDto dto)
    {
        var token = await _authService.AuthenticateAsync(dto);

        return Ok(token);
    }
}

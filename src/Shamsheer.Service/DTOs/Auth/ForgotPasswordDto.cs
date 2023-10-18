namespace Shamsheer.Service.DTOs.Auth;

public class ForgotPasswordDto
{
    public string Email { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}

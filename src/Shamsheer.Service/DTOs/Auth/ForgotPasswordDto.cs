using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Auth;

public class ForgotPasswordDto
{
    [Required]
    [EmailValidation(ErrorMessage = "Invalid email format!")]
    public string Email { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}

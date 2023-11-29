using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Auth;

public class ForgotPasswordDto
{
    [Required]
    [ShEmail(ErrorMessage = "Invalid email format!")]
    public string Email { get; set; } 
    public string NewPassword { get; set; }
}

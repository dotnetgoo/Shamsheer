using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Users;

public class UserForLoginDto
{
    [Required]
    [EmailValidation(ErrorMessage = "Invalid email format!")]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

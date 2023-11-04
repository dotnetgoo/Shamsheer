using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Users;

public class UserForSendCodeDto
{
    [Required]
    [EmailValidation(ErrorMessage = "Invalid email format!")]
    public string Email { get; set; } = string.Empty;
}

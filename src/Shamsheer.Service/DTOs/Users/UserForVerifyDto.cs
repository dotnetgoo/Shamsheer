using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Users;

public class UserForVerifyDto
{
    [Required]
    [EmailValidation(ErrorMessage = "Invalid email format!")]
    public string Email { get; set; } = string.Empty;
    public int Code { get; set; }
}

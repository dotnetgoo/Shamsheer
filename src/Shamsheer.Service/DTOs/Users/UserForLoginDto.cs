using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Users;

public class UserForLoginDto
{
    [Required]
    [ShEmail(ErrorMessage = "Invalid email format!")]
    public string Email { get; set; } 
    public string Password { get; set; } 
}

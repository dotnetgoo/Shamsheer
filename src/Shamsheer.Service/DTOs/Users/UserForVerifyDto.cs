using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Users;

public class UserForVerifyDto
{
    [Required]
    [ShEmail(ErrorMessage = "Invalid email format!")]
    public string Email { get; set; }
    public int Code { get; set; }
}

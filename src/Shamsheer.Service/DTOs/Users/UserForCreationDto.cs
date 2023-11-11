using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Users;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Required]
    [ShEmail(ErrorMessage ="Invalid email format!")]
    public string Email { get; set; }
    public string Phone { get; set; }
}

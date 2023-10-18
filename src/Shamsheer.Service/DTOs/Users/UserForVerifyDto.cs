namespace Shamsheer.Service.DTOs.Users;

public class UserForVerifyDto
{
    public string Email { get; set; } = string.Empty;
    public int Code { get; set; }
}

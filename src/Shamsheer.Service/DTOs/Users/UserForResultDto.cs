using Shamsheer.Service.DTOs.UserAssets;
using System.Collections.Generic;

namespace Shamsheer.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Description { get; set; }
    public string Username { get; set; }
    public ICollection<UserAssetForResultDto> Assets { get; set; }
}

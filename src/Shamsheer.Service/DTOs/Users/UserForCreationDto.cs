using Shamsheer.Service.DTOs.UserAssets;
using System.Collections.Generic;

namespace Shamsheer.Service.DTOs.Users;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserAssetForCreationDto Assets { get; set; }
}

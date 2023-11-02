﻿using Shamsheer.Service.DTOs.UserAssets;

namespace Shamsheer.Service.DTOs.Users;

public class UserForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Description { get; set; }

}
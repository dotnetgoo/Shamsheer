using Shamsheer.Domain.Entities.Chats;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.UserGroups;

public class UserGroupSeedData
{
    public static IEnumerable<UserGroup> GetMockUserGroups()
    {
        var userGroups = new List<UserGroup>
        {
            new UserGroup
            {
                MemberId = 1,
                GroupId = 1,
                RoleId = 3, // Admin
            },
            new UserGroup
            {
                MemberId = 2,
                GroupId = 1,
                RoleId = 1, // Member
            },
            new UserGroup
            {
                MemberId = 3,
                GroupId = 2,
                RoleId = 3, // Admin
            },
            new UserGroup
            {
                MemberId = 4,
                GroupId = 2,
                RoleId = 1, // Member
            },
        };

        return userGroups;
    }
}


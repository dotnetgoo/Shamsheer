using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Groups;

public class GroupRoleSeedData
{
    public static IEnumerable<GroupRole> GetMockData()
    {
        var groupRoles = new List<GroupRole>
        {
            new GroupRole { ChatRole = ChatRole.Member },
            new GroupRole { ChatRole = ChatRole.Subscriber },
            new GroupRole { ChatRole = ChatRole.Admin },
            new GroupRole { ChatRole = ChatRole.Banned },
            new GroupRole { ChatRole = ChatRole.Restricted },
        };

        return groupRoles;
    }
}

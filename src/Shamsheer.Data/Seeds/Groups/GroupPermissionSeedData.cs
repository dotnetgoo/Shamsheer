using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Groups;

public class GroupPermissionSeedData
{
    public static IEnumerable<GroupPermission> GetMockData()
    {

        var groupPermissions = new List<GroupPermission>
        {
            new GroupPermission { Type = GroupPermissionType.ChangeGroupInfo },
            new GroupPermission { Type = GroupPermissionType.DeleteMessages },
            new GroupPermission { Type = GroupPermissionType.BannedUsers },
            new GroupPermission { Type = GroupPermissionType.InviteViaLink },
            new GroupPermission { Type = GroupPermissionType.PinMessages },
            new GroupPermission { Type = GroupPermissionType.AddNewAdmin },
            new GroupPermission { Type = GroupPermissionType.AllPermissions },
            
        };

        return groupPermissions;
    }
}

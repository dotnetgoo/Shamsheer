using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Domain.Entities.Authorizations.Groups;

public class GroupPermission : Auditable
{
    public GroupPermissionType Type { get; set; }

    //public ICollection<GroupRolePermission> GroupRolePermissions { get; set; }

}

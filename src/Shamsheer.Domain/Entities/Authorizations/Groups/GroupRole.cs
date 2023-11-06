using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Domain.Entities.Authorizations.Groups
{
    public class GroupRole : Auditable
    {
        public ChatRole ChatRole { get; set; }


       // public ICollection<GroupRolePermission> GroupRolePermissions { get; set; }

    }
}

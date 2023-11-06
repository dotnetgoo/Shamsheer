using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Authorizations.Groups
{
    public class GroupRolePermission : Auditable
    {
        public long RoleId { get; set; }
        public GroupRole Role { get; set; }
        public long PermissionId { get; set; }
        public GroupPermission Permission { get; set; }

        public long UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}

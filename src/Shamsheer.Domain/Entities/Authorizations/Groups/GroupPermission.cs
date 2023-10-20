using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Domain.Entities.Authorizations.Groups;

public class GroupPermission : Auditable
{
    public GroupPermissionType Type { get; set; }

}

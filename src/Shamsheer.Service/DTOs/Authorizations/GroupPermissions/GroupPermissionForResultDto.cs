using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Service.DTOs.Authorizations.GroupPermissions;

public class GroupPermissionForResultDto
{
    public long Id { get; set; }
    public GroupPermissionType Type { get; set; }
}

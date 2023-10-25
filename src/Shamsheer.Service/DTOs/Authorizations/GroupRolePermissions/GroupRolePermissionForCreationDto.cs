using Shamsheer.Domain.Entities.Authorizations.Groups;

namespace Shamsheer.Service.DTOs.Authorizations.GroupRolePermissions;

public class GroupRolePermissionForCreationDto
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }
}

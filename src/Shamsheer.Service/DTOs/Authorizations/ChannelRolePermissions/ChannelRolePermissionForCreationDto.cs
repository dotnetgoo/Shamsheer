using Shamsheer.Domain.Entities.Authorizations.Channels;

namespace Shamsheer.Service.DTOs.Authorizations.ChannelRolePermissions;

public class ChannelRolePermissionForCreationDto
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }
}

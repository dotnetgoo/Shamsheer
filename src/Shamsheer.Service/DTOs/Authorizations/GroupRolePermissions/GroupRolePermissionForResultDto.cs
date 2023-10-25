using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.Channels;
using Shamsheer.Service.DTOs.Authorizations.GroupPermissions;
using Shamsheer.Service.DTOs.Authorizations.Groups;

namespace Shamsheer.Service.DTOs.Authorizations.GroupRolePermissions;

public class GroupRolePermissionForResultDto
{
    public long Id { get; set; }
    public GroupRoleForResultDto Role { get; set; }
    public GroupPermissionForResultDto Permission { get; set; }
}

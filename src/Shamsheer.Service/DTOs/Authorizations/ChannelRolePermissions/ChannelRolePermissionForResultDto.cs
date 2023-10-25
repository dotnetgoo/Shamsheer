using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;
using Shamsheer.Service.DTOs.Authorizations.Channels;

namespace Shamsheer.Service.DTOs.Authorizations.ChannelRolePermissions;

public class ChannelRolePermissionForResultDto
{
    public long Id { get; set; }
    public ChannelRoleForResultDto Role { get; set; }
    public ChannelPermissionForResultDto Permission { get; set; }
}

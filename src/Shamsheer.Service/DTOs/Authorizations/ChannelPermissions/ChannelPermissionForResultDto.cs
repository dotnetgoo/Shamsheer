using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Service.DTOs.Authorizations.ChannelPermissions;

public class ChannelPermissionForResultDto
{
    public long Id { get; set; }
    public ChannelPermissionType Type { get; set; }
}

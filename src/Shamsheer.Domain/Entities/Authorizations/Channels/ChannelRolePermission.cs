
using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Chats;

namespace Shamsheer.Domain.Entities.Authorizations.Channels;

public class ChannelRolePermission : Auditable
{
    public long RoleId { get; set; }
    public ChannelRole Role { get; set; }

    public long PermissionId { get; set; }
    public ChannelPermission Permission { get; set; }

    public long UserChannelId { get; set; }

    public UserChannel UserChannel { get; set; } 
}

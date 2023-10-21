using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Domain.Entities.Authorizations.Channels;

public class ChannelPermission : Auditable
{
    public ChannelPermissionType Type { get; set; }

}

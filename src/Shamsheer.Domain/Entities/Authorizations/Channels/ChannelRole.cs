using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Domain.Entities.Authorizations.Channels;

public class ChannelRole : Auditable
{
    public ChatRole ChatRole { get; set; }

}

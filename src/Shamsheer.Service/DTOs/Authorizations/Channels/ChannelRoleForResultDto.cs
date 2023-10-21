using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Service.DTOs.Authorizations.Channels;

public class ChannelRoleForResultDto
{
    public long Id { get; set; }
    public ChatRole ChatRole { get; set; }
}

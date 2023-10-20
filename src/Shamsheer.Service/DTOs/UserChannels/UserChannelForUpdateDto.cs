using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Service.DTOs.UserChannels;
public class UserChannelForUpdateDto
{
    public long SubscriberId { get; set; }
    public long ChannelId { get; set; }
    public ChatRole Role { get; set; }
}
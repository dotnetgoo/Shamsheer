using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Users;
using Shamsheer.Service.DTOs.Channels;

namespace Shamsheer.Service.DTOs.UserChannels;
public class UserChannelForResultDto
{
    public long Id { get; set; }
    public UserForResultDto Subscriber { get; set; }
    public ChannelForResultDto Channel { get; set; }
    public ChatRole Role { get; set; }
}

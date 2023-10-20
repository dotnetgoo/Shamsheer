using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Users;

namespace Shamsheer.Service.DTOs.Channels;
public class ChannelForResultDto
{
    public long Id { get; set; }
    public UserForResultDto Owner { get; set; }
    public string Description { get; set; }
    public string Username { get; set; }
    public string Title { get; set; }
    public string InviteLink { get; set; }
    public ChatAccessType AccessType { get; set; }
}
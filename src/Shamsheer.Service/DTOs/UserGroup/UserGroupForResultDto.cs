using Shamsheer.Domain.Enums.Chats;
using Shamsheer.Service.DTOs.Groups;
using Shamsheer.Service.DTOs.Users;

namespace Shamsheer.Service.DTOs.UserGroup;

public class UserGroupForResultDto
{
    public long Id { get; set; }
    public UserForResultDto Member { get; set; }
    public GroupForResultDto Group { get; set; }
    public ChatRole Role { get; set; }
}

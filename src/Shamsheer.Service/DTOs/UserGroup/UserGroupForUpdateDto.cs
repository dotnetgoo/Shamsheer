using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Service.DTOs.UserGroup;

public class UserGroupForUpdateDto
{
    public long MemberId { get; set; }
    public long GroupId { get; set; }
    public ChatRole Role { get; set; }
}

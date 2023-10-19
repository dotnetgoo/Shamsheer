using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Service.DTOs.UserGroup;

public class UserGroupForCreationDto
{
    public long MemberId { get; set; }
    public long GroupId { get; set; }
}

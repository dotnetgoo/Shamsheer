using Shamsheer.Domain.Enums.Chats;

namespace Shamsheer.Service.DTOs.Authorizations.Groups;

public class GroupRoleForResultDto
{
    public long Id { get; set; }
    public ChatRole ChatRole { get; set; }
}

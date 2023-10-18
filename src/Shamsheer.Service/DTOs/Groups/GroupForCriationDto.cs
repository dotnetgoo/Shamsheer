using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Service.DTOs.Groups;

public class GroupForCriationDto
{
    public string Description { get; set; }
    public string Username { get; set; }
    public ChatType ChatType { get; set; }
    public string Title { get; set; }
    public ChatAccessType AccessType { get; set; }
    public ICollection<UserGroup> Members { get; set; }
    public ICollection<GroupAsset> Assets { get; set; }
}

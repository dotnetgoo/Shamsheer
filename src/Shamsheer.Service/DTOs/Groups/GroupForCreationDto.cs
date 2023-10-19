using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Service.DTOs.Groups;

public class GroupForCreationDto
{
    public long OwnerId { get; set; }
    public string Title { get; set; }
}

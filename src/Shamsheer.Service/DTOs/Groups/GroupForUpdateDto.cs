using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shamsheer.Service.DTOs.Groups;

public class GroupForUpdateDto
{
    public ChatAccessType AccessType { get; set; }

}

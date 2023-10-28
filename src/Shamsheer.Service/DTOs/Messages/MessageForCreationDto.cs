using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Entities.Messages;
using Shamsheer.Domain.Enums.Messages;
using Shamsheer.Domain.Enums;

namespace Shamsheer.Service.DTOs.Messages;

public class MessageForCreationDto
{
    public MessageType Type { get; set; }
    public FormatType FormatType { get; set; }

    public long? ParentId { get; set; }

    public long ToId { get; set; }
}

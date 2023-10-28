using Shamsheer.Domain.Enums.Messages;
using Shamsheer.Domain.Enums;

namespace Shamsheer.Service.DTOs.Messages;

public class MessageForUpdateDto
{
    public MessageType Type { get; set; }
    public FormatType FormatType { get; set; }

    public long? ParentId { get; set; }

    public long ToId { get; set; }
}

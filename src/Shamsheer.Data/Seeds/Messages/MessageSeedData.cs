using Shamsheer.Domain.Entities.Messages;
using Shamsheer.Domain.Enums;
using Shamsheer.Domain.Enums.Messages;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Messages;

public class MessageSeedData
{
    public static IEnumerable<Message> GetMockData()
    {
        var messages = new List<Message>
        {
            new Message
            {
                Type = MessageType.Text,
                FormatType = FormatType.Regular,
                FromId = 1, // Sender's ID
                ToId = 2,   // Receiver's ID
            },
            new Message
            {
                Type = MessageType.Photo,
                FormatType = FormatType.Regular,
                FromId = 2, // Sender's ID
                ToId = 1,   // Receiver's ID
            },
        };

        return messages;
    }
}

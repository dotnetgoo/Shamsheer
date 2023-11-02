using Shamsheer.Domain.Entities.Messages;
using Shamsheer.Domain.Enums;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Messages
{
    public class MessageContentSeedData
    {
        public static IEnumerable<MessageContent> GetMockData()
        {
            var messageContents = new List<MessageContent>
            {
                new MessageContent
                {
                    Content = new byte[] { 0x12, 0x34, 0x56 },
                    ContentType = MessageType.Text,
                    MessageId = 1, // Message's ID
                },
                new MessageContent
                {
                    Content = new byte[] { 0x45, 0x67, 0x89 },
                    ContentType = MessageType.Photo,
                    MessageId = 2, // Message's ID
                },
            };

            return messageContents;
        }
    }
}

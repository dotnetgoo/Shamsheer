using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Messages
{
    public class MessageContent : Auditable
    {
        public byte[] Content { get; set; }
        public MessageType ContentType { get; set; }
        public long MessageId { get; set; }
        public Message Message { get; set; }
    }
}

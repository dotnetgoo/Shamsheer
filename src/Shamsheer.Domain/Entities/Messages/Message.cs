using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums;
using Shamsheer.Domain.Enums.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Messages
{
    public class Message : Auditable
    {
        public MessageType Type { get; set; }
        public FormatType FormatType { get; set; }

        public long? ParentId { get; set; }
        public Message Parent { get; set; }
        public long FromId { get; set; }
        public User From { get; set; }

        public long ToId { get; set; }
        public User To { get; set; }
    }
}

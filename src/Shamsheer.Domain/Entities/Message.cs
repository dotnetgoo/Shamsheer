using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities
{
    public class Message : Auditable
    {
        public MessageType Type { get; set; }

        public long ContentId { get; set; }
        public MessageContent Content { get; set; }

        public Message Parent { get; set; }
        public long? ParentId { get; set; }
        
        /// <summary>
        /// ijuhnbik
        /// </summary>
        public User From { get; set; }
        public long FromId { get; set; }

        public User To { get; set; }
        public long ToId { get; set; }
    }
}

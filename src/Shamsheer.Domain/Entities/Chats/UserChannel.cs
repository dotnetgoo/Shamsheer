using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Chats
{
    public class UserChannel : Auditable
    {
        public long SubscriberId { get; set; }
        public User Subscriber { get; set; }

        public long ChannelId { get; set; }
        public Channel Channel { get; set; }

        public ChatRole Role { get; set; }
    }
}

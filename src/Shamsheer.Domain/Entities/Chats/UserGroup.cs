using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Enums.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Chats
{
    public class UserGroup : Auditable
    {
        public long MemberId { get; set; }
        public User Member { get; set; }

        public long GroupId { get; set; }
        public Group Group { get; set; }

        public ChatRole Role { get; set; }
    }
}

﻿using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Enums.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Chats
{
    public class Group : Chat
    {
        public long OwnerId { get; set; }
        public User Owner { get; set; }

        public string Title { get; set; }
        public ChatAccessType AccessType { get; set; }
        public string InviteLink { get; set; }
        public ICollection<UserGroup> Members { get; set; }
        public ICollection<GroupAsset> Assets { get; set; }
    }
}

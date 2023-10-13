using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Enums;
using Shamsheer.Domain.Enums.Chats;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Chats
{
    public abstract class Chat : Auditable
    {
        public string Description { get; set; }
        public string Username { get; set; }
        public ChatType ChatType { get; set; }
    }
}

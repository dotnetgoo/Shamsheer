using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Assets
{
    public class UserAsset : Asset
    {
        public long UserId { get; set; }
        public User User { get; set; }
    }
}

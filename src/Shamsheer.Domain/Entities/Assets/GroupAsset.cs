using Shamsheer.Domain.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Assets
{
    public class GroupAsset : Asset
    {
        public long GroupId { get; set; }
        public Group Group { get; set; }
    }
}

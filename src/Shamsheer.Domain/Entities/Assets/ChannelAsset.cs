using Shamsheer.Domain.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Domain.Entities.Assets
{
    public class ChannelAsset : Asset
    {
        public long ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}

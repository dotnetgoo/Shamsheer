using Shamsheer.Domain.Commons;
using Shamsheer.Domain.Entities.Authorizations.Channels;

namespace Shamsheer.Domain.Entities.Chats
{
    public class UserChannel : Auditable
    {
        public long SubscriberId { get; set; }
        public User Subscriber { get; set; }

        public long ChannelId { get; set; }
        public Channel Channel { get; set; }

        public long RoleId { get; set; }
        public ChannelRole ChannelRole { get; set; }
    }
}

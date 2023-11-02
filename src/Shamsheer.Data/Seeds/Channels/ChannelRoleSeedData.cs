using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Channels;

public class ChannelRoleSeedData
{
    public static IEnumerable<ChannelRole> GetMockData()
    {
        var channelRoles = new List<ChannelRole>
        {
            new ChannelRole { ChatRole = ChatRole.Subscriber },
            new ChannelRole { ChatRole = ChatRole.Admin },
            new ChannelRole { ChatRole = ChatRole.Banned },
        };

        return channelRoles;
    }
}

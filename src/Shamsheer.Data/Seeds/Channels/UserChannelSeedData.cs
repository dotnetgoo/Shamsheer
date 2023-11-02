using Shamsheer.Domain.Entities.Chats;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Channels;

public class UserChannelSeedData
{
    public static IEnumerable<UserChannel> GetMockData()
    {
        var userChannels = new List<UserChannel>
        {
            new UserChannel
            {
                SubscriberId = 1,
                ChannelId = 1,
                RoleId = 2, // Admin
            },
            new UserChannel
            {
                SubscriberId = 2,
                ChannelId = 1,
                RoleId = 1, // Subscriber
            },
            new UserChannel
            {
                SubscriberId = 3,
                ChannelId = 2,
                RoleId = 2, // Admin
            },
            new UserChannel
            {
                SubscriberId = 4,
                ChannelId = 2,
                RoleId = 1, // Subscriber
            },
        };

        return userChannels;
    }
}

using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Channels;

public class ChannelsSeedData
{
    public static IEnumerable<Channel> GetMockData()
    {
        var channels = new List<Channel>
        {
            new Channel
            {
                Id = 1,
                OwnerId = 1,
                Title = "Tech News",
                AccessType = ChatAccessType.Public,
                InviteLink = "tech-news-invite",
                Subscribers = new List<UserChannel>(),
                Assets = new List<ChannelAsset>()
            },
            new Channel
            {
                Id = 2,
                OwnerId = 2,
                Title = "Travel Tips",
                AccessType = ChatAccessType.Public,
                InviteLink = "travel-tips-invite",
                Subscribers = new List<UserChannel>(),
                Assets = new List<ChannelAsset>()
            },

        };

        return channels;
    }
}

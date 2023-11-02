using Shamsheer.Domain.Entities.Assets;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Assets;

public class ChannelAssetSeedData
{
    public static IEnumerable<ChannelAsset> GetMockData()
    {
        var channelAssets = new List<ChannelAsset>
        {
            new ChannelAsset { ChannelId = 1 },
            new ChannelAsset { ChannelId = 2 },
            new ChannelAsset { ChannelId = 2 },
            new ChannelAsset { ChannelId = 3 },
        };

        return channelAssets;
    }
}
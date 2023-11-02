using Shamsheer.Domain.Entities.Assets;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Assets;

public class GroupAssetSeedData
{
    public static IEnumerable<GroupAsset> GetMockGroupAssets()
    {
        var groupAssets = new List<GroupAsset>
        {
            new GroupAsset { GroupId = 1 },
            new GroupAsset { GroupId = 2 },
            new GroupAsset { GroupId = 2 },
            new GroupAsset { GroupId = 3 },
        };

        return groupAssets;
    }
}

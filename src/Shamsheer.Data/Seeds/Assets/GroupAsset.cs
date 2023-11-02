using Shamsheer.Domain.Entities.Assets;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Assets;

public class GroupAssetSeedData
{
    public static IEnumerable<GroupAsset> GetMockGroupAssets()
    {
        // Create sample GroupAsset entities
        var groupAssets = new List<GroupAsset>
        {
            new GroupAsset { GroupId = 1 },
            new GroupAsset { GroupId = 2 },
            new GroupAsset { GroupId = 2 },
            new GroupAsset { GroupId = 3 },
            // Add more GroupAsset entities as needed
        };

        return groupAssets;
    }
}

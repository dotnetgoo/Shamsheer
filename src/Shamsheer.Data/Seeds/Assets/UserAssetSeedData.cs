using Shamsheer.Domain.Entities.Assets;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Assets;

public class UserAssetSeedData
{
    public static IEnumerable<UserAsset> GetMockData()
    {
        // Create sample UserAsset entities
        var userAssets = new List<UserAsset>
        {
            new UserAsset
            {
                UserId = 1, // User's ID
            },
            new UserAsset
            {
                UserId = 2, // User's ID
            },
            // Add more UserAsset entities as needed
        };

        return userAssets;
    }
}

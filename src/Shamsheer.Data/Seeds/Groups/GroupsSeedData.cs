using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Groups;

public class GroupsSeedData
{
    public static IEnumerable<Group> GetMockData()
    {
        var groups = new List<Group>
        {
            new Group
            {
                Id = 1,
                OwnerId = 1,
                Title = "Tech Enthusiasts",
                AccessType = ChatAccessType.Public,
                InviteLink = "tech-enthusiasts-invite",
                Members = new List<UserGroup>(),
                Assets = new List<GroupAsset>()
            },
            new Group
            {
                Id = 2,
                OwnerId = 2,
                Title = "Travel Explorers",
                AccessType = ChatAccessType.Public,
                InviteLink = "travel-explorers-invite",
                Members = new List<UserGroup>(),
                Assets = new List<GroupAsset>()
            },

        };

        return groups;
    }
}

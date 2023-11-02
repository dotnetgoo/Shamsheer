using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Domain.Enums.Chats;
using System;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Channels
{
    public class ChannelPermissionSeedData
    {
        public static IEnumerable<ChannelPermission> GetMockData()
        {
            var channelPermissions = new List<ChannelPermission>
            {
                new ChannelPermission { Type = ChannelPermissionType.ChangeChannelInfo },
                new ChannelPermission { Type = ChannelPermissionType.ManageMessages },
                new ChannelPermission { Type = ChannelPermissionType.AddMembers },
                new ChannelPermission { Type = ChannelPermissionType.AddNewAdmins },
            };

            return channelPermissions;
        }
    }
}

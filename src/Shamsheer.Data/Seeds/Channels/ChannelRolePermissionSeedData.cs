using Shamsheer.Domain.Entities.Authorizations.Channels;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Channels
{
    public class ChannelRolePermissionSeedData
    {
        public static IEnumerable<ChannelRolePermission> GetMockData()
        {
            var rolePermissions = new List<ChannelRolePermission>
            {
                new ChannelRolePermission
                {
                    RoleId = 1, // Role's ID
                    PermissionId = 1, // Permission's ID
                },
                new ChannelRolePermission
                {
                    RoleId = 2, // Role's ID
                    PermissionId = 2, // Permission's ID
                },
            };

            return rolePermissions;
        }
    }
}

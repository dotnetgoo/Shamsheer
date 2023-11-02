using Shamsheer.Domain.Entities.Authorizations.Groups;
using System;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Groups
{
    public class GroupRolePermissionSeedData
    {
        public static IEnumerable<GroupRolePermission> GetMockData()
        {
            var rolePermissions = new List<GroupRolePermission>
            {
                new GroupRolePermission
                {
                    RoleId = 1, // Role's ID
                    PermissionId = 1, // Permission's ID
                },
                new GroupRolePermission
                {
                    RoleId = 2, // Role's ID
                    PermissionId = 2, // Permission's ID
                },
            };

            return rolePermissions;
        }
    }
}

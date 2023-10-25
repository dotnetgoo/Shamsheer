using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Data.Repositories;

public class GroupRolePermissionRepository : Repository<GroupRolePermission>, IGroupRolePermissionRepository
{
    public GroupRolePermissionRepository(ShamsheerDbContext dbContext) : base(dbContext)
    { }
}

using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Groups;

namespace Shamsheer.Data.Repositories;

public class GroupPermissionRepository : Repository<GroupPermission>, IGroupPermissionRepository
{
    public GroupPermissionRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

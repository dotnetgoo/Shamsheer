using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Groups;

namespace Shamsheer.Data.Repositories;

public class GroupRoleRepository : Repository<GroupRole>, IGroupRoleRepository
{
    public GroupRoleRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

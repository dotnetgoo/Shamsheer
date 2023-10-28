using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Chats;

namespace Shamsheer.Data.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

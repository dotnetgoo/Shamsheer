using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Channels;

namespace Shamsheer.Data.Repositories;

public class ChannelRoleRepository : Repository<ChannelRole>, IChannelRoleRepository
{
    public ChannelRoleRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Channels;

namespace Shamsheer.Data.Repositories;

public class ChannelPermissionRepository : Repository<ChannelPermission>, IChannelPermissionRepository
{
    public ChannelPermissionRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

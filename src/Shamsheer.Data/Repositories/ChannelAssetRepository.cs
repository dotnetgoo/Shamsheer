using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Assets;

namespace Shamsheer.Data.Repositories;

public class ChannelAssetRepository : Repository<ChannelAsset>, IChannelAssetRepository
{
    public ChannelAssetRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

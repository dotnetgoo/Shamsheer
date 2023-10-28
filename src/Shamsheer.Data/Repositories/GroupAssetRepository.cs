using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Assets;

namespace Shamsheer.Data.Repositories;

public class GroupAssetRepository : Repository<GroupAsset>, IGroupAssetRepository
{
    public GroupAssetRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

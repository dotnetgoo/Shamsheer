using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Assets;

namespace Shamsheer.Data.Repositories;

public class UserAssetRepository : Repository<UserAsset>, IUserAssetRepository
{
    public UserAssetRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

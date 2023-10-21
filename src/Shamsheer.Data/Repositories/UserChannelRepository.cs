using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Chats;

namespace Shamsheer.Data.Repositories;
public class UserChannelRepository : Repository<UserChannel>, IUserChannelRepository
{
    public UserChannelRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}

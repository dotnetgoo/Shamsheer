using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Chats;

namespace Shamsheer.Data.Repositories;
public class ChannelRepository : Repository<Channel>, IChannelRepository
{
    public ChannelRepository(ShamsheerDbContext dbContext) : base(dbContext)
    {
    }
}
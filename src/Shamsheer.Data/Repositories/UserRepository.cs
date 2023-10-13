using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ShamsheerDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(long userId)
        {
            throw new NotImplementedException();
        }
    }
}

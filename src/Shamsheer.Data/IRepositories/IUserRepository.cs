using Shamsheer.Domain.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Data.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<Channel>> GetSubscribedChannelsAsync(long userId);
    }
}

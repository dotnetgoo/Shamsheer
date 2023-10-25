using Shamsheer.Data.DbContexts;
using Shamsheer.Data.IRepositories;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Data.Repositories
{
    public class ChannelRolePermissionRepository : Repository<ChannelRolePermission> , IChannelRolePermissionRepository
    {
        public ChannelRolePermissionRepository(ShamsheerDbContext dbContext) : base(dbContext)
        { }
    }
}

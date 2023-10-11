using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Data.DbContexts
{
    public class ShamsheerDbContext : DbContext
    {
        public ShamsheerDbContext(DbContextOptions<ShamsheerDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=ShamsheerDb; User Id=postgres; Password=root;");
            optionsBuilder.UseInMemoryDatabase("ShamsheerDb");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}

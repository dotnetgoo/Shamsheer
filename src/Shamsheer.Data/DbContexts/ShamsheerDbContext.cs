using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Domain.Entities.Authorizations.Groups;
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
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageContent> MessageContents { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserChannel> UserChannels { get; set; }
        public DbSet<UserAsset> UserAssets { get; set; }
        public DbSet<GroupAsset> GroupAssets { get; set; }
        public DbSet<ChannelAsset> ChannelAssets { get; set; }
        public DbSet<ChannelRole> ChannelRoles { get; set; }
        public DbSet<ChannelPermission> ChannelPermissions { get; set; }
        public DbSet<ChannelRolePermission> ChannelRolesPermissions { get; set; }
        public DbSet<GroupRole> GroupRoles { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<GroupRolePermission> GroupRolesPermissions { get; set; }
    }
}

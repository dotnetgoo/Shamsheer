using Microsoft.EntityFrameworkCore;
using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Entities.Assets;
using Shamsheer.Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shamsheer.Domain.Entities.Authorizations.Groups;
using Shamsheer.Domain.Entities.Authorizations.Channels;
using Shamsheer.Data.EntityConfigurations;
using System;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Shamsheer.Data.DbContexts;

public class ShamsheerDbContext : DbContext
{
    public ShamsheerDbContext(DbContextOptions<ShamsheerDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserAsset> UserAssets { get; set; }
    public DbSet<GroupRole> GroupRoles { get; set; }
    public DbSet<GroupAsset> GroupAssets { get; set; }
    public DbSet<UserChannel> UserChannels { get; set; }
    public DbSet<ChannelRole> ChannelRoles { get; set; }
    public DbSet<ChannelAsset> ChannelAssets { get; set; }
    public DbSet<MessageContent> MessageContents { get; set; }
    public DbSet<GroupPermission> GroupPermissions { get; set; }
    public DbSet<ChannelPermission> ChannelPermissions { get; set; }
    public DbSet<GroupRolePermission> GroupRolesPermissions { get; set; }
    public DbSet<ChannelRolePermission> ChannelRolesPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserGroupEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new UserChannelEntityTypeConfiguration());


        modelBuilder.ApplyConfiguration(new UserAssetEntityTypeConfiguration());


        modelBuilder.ApplyConfiguration(new GroupAssetEntityTypeConfiguration());


        modelBuilder.ApplyConfiguration(new ChannelAssetEntityTypeConfiguration());
             

        Task.Run(() =>
        {
            SeedUsers(modelBuilder);
        }).Wait();
    }

    private void SeedUsers(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasData(new User[]
            {
                new User
                {
                    Id = 1,
                    FirstName = "Mukhammadkarim",
                    LastName = "Tukhtaboev",
                    Email = "toxtaboyev.m@icloud.com",
                    Phone = "+998936090722",
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jaloliddin",
                    LastName = "G'anijonov",
                    Email = "jm7uzdev@gmail.com",
                    Phone = "+998911243901",
                    CreatedAt = DateTime.UtcNow
                }
            });
    }

    public void Configure(EntityTypeBuilder<Group> modelBuilder)
    {
        modelBuilder.ToTable("Groups");
        modelBuilder.HasKey(g => g.Id);
        modelBuilder.Property(g => g.OwnerId).IsRequired();
        modelBuilder.Property(g => g.Title).HasMaxLength(64);
        modelBuilder.Property(g => g.ChatType).IsRequired();
        modelBuilder.Property(g => g.Username).HasMaxLength(64);
        modelBuilder.Property(g => g.InviteLink).HasMaxLength(256);
        modelBuilder.Property(g => g.Description).HasMaxLength(256);

    }
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {
        modelBuilder.ToTable(nameof(Users));
        modelBuilder.HasKey(g => g.Id);
        modelBuilder.Property(u => u.Email).HasMaxLength(50);
        modelBuilder.Property(g => g.ChatType).IsRequired();
        modelBuilder.Property(g => g.Phone).HasMaxLength(50);
        modelBuilder.Property(g => g.Username).HasMaxLength(64);
        modelBuilder.Property(g => g.Description).HasMaxLength(256);
        modelBuilder.Property(g => g.FirstName).HasMaxLength(50).IsRequired();
        modelBuilder.Property(g => g.LastName).HasMaxLength(50).HasMaxLength(64);
    }

    public void Configure(EntityTypeBuilder<Chat> modelBuilder)
    {
        modelBuilder.ToTable("Chats");
        modelBuilder.HasKey(g => g.Id);
        modelBuilder.Property(g => g.ChatType).IsRequired();
        modelBuilder.Property(g => g.Username).HasMaxLength(64);
        modelBuilder.Property(g => g.Description).HasMaxLength(256);

    }


}


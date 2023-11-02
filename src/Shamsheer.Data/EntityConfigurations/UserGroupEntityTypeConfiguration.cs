using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shamsheer.Domain.Entities.Chats;

namespace Shamsheer.Data.EntityConfigurations;

public class UserGroupEntityTypeConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasOne(g => g.Group)
            .WithMany(m => m.Members)
            .HasForeignKey(g => g.MemberId);


    }
}

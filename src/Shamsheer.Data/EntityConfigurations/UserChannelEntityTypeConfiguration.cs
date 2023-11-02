using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shamsheer.Domain.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Data.EntityConfigurations
{
    public class UserChannelEntityTypeConfiguration : IEntityTypeConfiguration<UserChannel>
    {
        public void Configure(EntityTypeBuilder<UserChannel> builder)
        {
            builder.HasOne(c => c.Channel)
                .WithMany(s => s.Subscribers)
                .HasForeignKey(c => c.ChannelId);
        }
    }
}

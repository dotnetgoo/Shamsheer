using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shamsheer.Domain.Entities.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamsheer.Data.EntityConfigurations
{
    public class ChannelAssetEntityTypeConfiguration : IEntityTypeConfiguration<ChannelAsset>
    {
        public void Configure(EntityTypeBuilder<ChannelAsset> builder)
        {
            builder.HasOne(c => c.Channel)
                .WithMany(a => a.Assets)
                .HasForeignKey(c => c.ChannelId);
        }
    }
}

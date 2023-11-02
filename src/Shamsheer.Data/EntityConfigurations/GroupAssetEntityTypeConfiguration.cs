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
    public class GroupAssetEntityTypeConfiguration : IEntityTypeConfiguration<GroupAsset>
    {
        public void Configure(EntityTypeBuilder<GroupAsset> builder)
        {
            builder.HasOne(g => g.Group)
                .WithMany(a => a.Assets)
                .HasForeignKey(g => g.GroupId);
        }
    }
}

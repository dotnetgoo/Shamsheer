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
    public class UserAssetEntityTypeConfiguration : IEntityTypeConfiguration<UserAsset>
    {
        public void Configure(EntityTypeBuilder<UserAsset> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(a => a.Assets)
                .HasForeignKey(u => u.UserId);
        }
    }
}

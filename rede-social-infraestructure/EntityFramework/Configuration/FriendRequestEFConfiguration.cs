using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rede_social_domain.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_infraestructure.EntityFramework.Configuration
{
    public class FriendRequestEFConfiguration : IEntityTypeConfiguration<FriendRequestEF>
    {
        public void Configure(EntityTypeBuilder<FriendRequestEF> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.FromUserId)
                .IsRequired();

            builder.Property(x => x.ToUserId)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasDefaultValue("P")
                .IsRequired();

            builder.Property(e => e.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rede_social_domain.Models.EFModels;
using rede_social_domain.Utils;

namespace rede_social_infraestructure.EntityFramework.Configuration
{
    public class FriendRequestEFConfiguration : IEntityTypeConfiguration<FriendRequestEF>
    {
        public void Configure(EntityTypeBuilder<FriendRequestEF> builder)
        {
            builder.HasKey(x => new { x.ToUserId, x.FromUserId });

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
                .HasDefaultValue(Utils.DateTimeOffset())
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}

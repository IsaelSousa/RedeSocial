using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rede_social_domain.Models.EFModels;

namespace rede_social_infraestructure.EntityFramework.Configuration
{
    public class FriendListEFConfiguration : IEntityTypeConfiguration<FriendListEF>
    {
        public void Configure(EntityTypeBuilder<FriendListEF> builder)
        {
            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.FriendId)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder.Property(x => x.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();
        }
    }
}

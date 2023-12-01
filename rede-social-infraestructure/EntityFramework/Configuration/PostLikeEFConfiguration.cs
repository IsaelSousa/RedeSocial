using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rede_social_domain.Models.EFModels;

namespace rede_social_infraestructure.EntityFramework.Configuration
{
    internal class PostLikeEFConfiguration : IEntityTypeConfiguration<PostLikes>
    {
        public void Configure(EntityTypeBuilder<PostLikes> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.PostId)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rede_social_domain.Models.EFModels;

namespace rede_social_infraestructure.EntityFramework.Configuration
{
    internal class PostEFConfiguration : IEntityTypeConfiguration<PostEF>
    {
        public void Configure(EntityTypeBuilder<PostEF> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .HasDefaultValue(null)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.PostMessage)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.Image)
                .HasDefaultValue(null);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder.Property(x => x.LastUpdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}

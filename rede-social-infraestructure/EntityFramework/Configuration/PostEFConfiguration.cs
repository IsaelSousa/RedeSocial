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
    internal class PostEFConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasDefaultValue(Guid.NewGuid().ToString())
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.PostMessage)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.Image)
                .HasDefaultValue(null);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(x => x.LastUpdated)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}

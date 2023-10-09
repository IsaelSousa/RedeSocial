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
    internal class PostCommentEFConfiguration : IEntityTypeConfiguration<PostComments>
    {
        public void Configure(EntityTypeBuilder<PostComments> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PostId)
                .IsRequired();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.Comment)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(e => e.Image);

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            builder.Property(e => e.LastUpdated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();
        }
    }
}

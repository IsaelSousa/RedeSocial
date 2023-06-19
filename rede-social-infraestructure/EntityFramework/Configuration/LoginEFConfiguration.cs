using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rede_social_domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_infraestructure.EntityFramework.Configuration
{
    internal class LoginEFConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            //builder.HasKey(x => x.Id);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(x => x.UpdatedAt)
                .ValueGeneratedOnUpdate()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities;
using rede_social_infraestructure.EntityFramework.Configuration;
using System.Reflection.Metadata;

namespace rede_social_infraestructure.EntityFramework.Context
{
    public class EFContext : DbContext
    {
        public string schema = "Social";
        public DbSet<Login> Logins { get; set; }
        public string DbPath { get; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(schema);

            modelBuilder.ApplyConfiguration(new LoginEFConfiguration());
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

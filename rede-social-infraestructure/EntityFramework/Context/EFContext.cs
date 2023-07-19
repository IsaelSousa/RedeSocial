using Microsoft.EntityFrameworkCore;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Configuration;

namespace rede_social_infraestructure.EntityFramework.Context
{
    public class EFContext : DbContext
    {
        public string schema = "Social";
        public DbSet<ApplicationUser> Logins { get; set; }
        public DbSet<PostModel> Post { get; set; }
        public DbSet<PostComments> PostComments { get; set; }
        public DbSet<PostLikes> PostLikes { get; set; }

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

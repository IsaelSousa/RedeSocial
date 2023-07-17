using Microsoft.EntityFrameworkCore;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Configuration;

namespace rede_social_infraestructure.EntityFramework.Context
{
    public class EFContext : DbContext
    {
        public string schema = "Social";
        public DbSet<ApplicationUser> Logins { get; set; }
        public DbSet<PostModel> post { get; set; }
        public DbSet<PostComments> postComments { get; set; }
        public DbSet<PostLikes> postLikes { get; set; }

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

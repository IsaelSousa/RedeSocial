using Microsoft.EntityFrameworkCore;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Configuration;

namespace rede_social_infraestructure.EntityFramework.Context
{
    public class EFContext : DbContext
    {
        public string schema = "dbo";

        //dotnet ef migrations add InitialMigration -p rede-social-infraestructure -s rede-social-api
        public DbSet<ApplicationUser> Logins { get; set; }
        public DbSet<PostEF> Post { get; set; }
        public DbSet<PostComments> PostComments { get; set; }
        public DbSet<PostLikes> PostLikes { get; set; }

        public string DbPath { get; }
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(schema);

            builder.ApplyConfiguration(new LoginEFConfiguration());
            builder.ApplyConfiguration(new PostCommentEFConfiguration());
            builder.ApplyConfiguration(new PostEFConfiguration());
            builder.ApplyConfiguration(new PostLikeEFConfiguration());

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

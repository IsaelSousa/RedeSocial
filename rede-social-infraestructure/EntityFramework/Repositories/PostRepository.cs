using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities.PostAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;
using System.Collections.Generic;
using System.Linq;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class PostRepository : IPostRepository
    {
        public EFContext DbContext { get; private set; }
        public DbSet<PostEF> DbSet { get; set; }
        public DbSet<ApplicationUser> Logins { get; private set; }

        public PostRepository() { }
        public PostRepository(EFContext dbContext) 
        {
            this.DbContext = dbContext;
            this.DbSet = this.DbContext.Set<PostEF>();
            this.Logins = this.DbContext.Set<ApplicationUser>();
        }

        public async Task<List<PostEF>> GetPostAsync()
        {
            var query = from post in DbSet
                        join user in Logins
                        on post.UserId equals user.Id
                        select new
                        {
                            Id = post.Id,
                            UserId = user.Id,
                            FirstName = user.FirstName,
                            PostMessage = post.PostMessage,
                            Image = post.Image,
                            CreatedAt = post.CreatedAt,
                            LastUpdated = post.LastUpdate
                        };

            var results = await query.ToListAsync();
            List<PostEF> data = new List<PostEF>();

            foreach (var result in results)
            {
                PostEF post = new PostEF();
                post.Id = result.Id;
                post.UserId = result.UserId;
                post.FirstName = result.FirstName;
                post.PostMessage = result.PostMessage;
                post.Image = result.Image;
                post.CreatedAt = result.CreatedAt;
                post.LastUpdate = result.LastUpdated;

                data.Add(post);
            }

            return data.OrderByDescending(num => num.CreatedAt).ToList();
        }

        public async Task<PostEF> InsertPost(PostEF post)
        {
            await this.DbSet.AddAsync(post);
            await this.DbContext.SaveChangesAsync();
            return post;
        }
    }
}

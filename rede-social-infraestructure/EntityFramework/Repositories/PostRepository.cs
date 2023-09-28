using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities.PostAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;
using System.Collections.Generic;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class PostRepository : IPostRepository
    {
        public EFContext _dbContext;

        public DbSet<Post> _posts;

        public PostRepository(EFContext dbContext)
        {
            this._dbContext = dbContext;

        }

        public async Task<IEnumerable<Post>> GetPost()
        {
            var data = await _posts.ToListAsync();
            return data;
        }
    }
}

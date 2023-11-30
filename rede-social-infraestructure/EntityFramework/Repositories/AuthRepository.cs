using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public EFContext _dbContext { get; private set; }
        public DbSet<ApplicationUser> DbSet { get; private set; }

        public AuthRepository(EFContext dbContext) 
        {
            this._dbContext = dbContext;
            this.DbSet = _dbContext.Set<ApplicationUser>();
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var data = await this.DbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return null;

            return data;
        }

        public async Task<ApplicationUser> GetUserName(string userName)
        {
            var data = await this.DbSet.FirstOrDefaultAsync(x => x.UserName == userName);

            if (data == null)
                return null;

            return data;
        }
    }
}

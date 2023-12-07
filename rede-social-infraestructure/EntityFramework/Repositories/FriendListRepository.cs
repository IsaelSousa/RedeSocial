using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.FriendListAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class FriendListRepository : IFriendListRepository
    {
        public EFContext _dbContext { get; private set; }
        public DbSet<FriendListEF> DbSet { get; private set; }

        public FriendListRepository(EFContext dbContext)
        {
            this._dbContext = dbContext;
            this.DbSet = _dbContext.Set<FriendListEF>();
        }

        public async Task<List<FriendListEF>> GetAllFriends(string userId)
        {
           return await this.DbSet.Where(x => x.UserId == userId && !x.IsDeleted).ToListAsync();
        }

        public async Task<FriendListEF> GetFriend(string userId, string toUserId)
        {
            return await this.DbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.FriendId == toUserId && !x.IsDeleted);
        }

        public async Task AddFriend(FriendListEF friendList)
        {
            var data = await this.GetAllFriends(friendList.UserId);

            if (data != null || data.Count() == 0)
            {
                await this.DbSet.AddAsync(friendList);
                await this._dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(FriendListEF friendList)
        {
            friendList.IsDeleted = true;
            friendList.LastUpdate = DateTime.Now;
            this.DbSet.Update(friendList);
            await this._dbContext.SaveChangesAsync();
        }
    }
}

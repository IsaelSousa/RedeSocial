using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        public EFContext _dbContext { get; private set; }
        public DbSet<FriendRequestEF> FriendEF { get; set; }
        public DbSet<ApplicationUser> Logins { get; private set; }


        public FriendRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
            FriendEF = this._dbContext.Set<FriendRequestEF>();
            this.Logins = this._dbContext.Set<ApplicationUser>();
        }

        public async Task<bool> CreateInvite(FriendRequestEF friendRequest)
        {
            var data = await this.FriendEF.AddAsync(friendRequest);
            if (data == null) return false;
            return true;
        } 

        public async Task ChangeStatusInvite(FriendRequestEF friendRequest)
        {
            this.FriendEF.Update(friendRequest);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<FriendRequestEF> GetPendentRequest(string fromUserId, string toUserId)
        {
            return await this.FriendEF.FirstOrDefaultAsync(x => 
            x.FromUserId == fromUserId
            && x.ToUserId == toUserId
            && x.Status == 'P'
            && !x.IsDeleted);
        }

        public async Task<List<FriendRequestList>> GetPendentUserRequestList(string userId)
        {
            var query = from friend in FriendEF.Where(x => x.ToUserId == userId)
                        join user in Logins
                        on friend.ToUserId equals user.Id
                        select new
                        {
                            UserName = user.UserName
                        };

            List<FriendRequestList> friendList = new List<FriendRequestList>();
            foreach (var item in await query.ToListAsync()) friendList.Add(new FriendRequestList(item.UserName));
            return friendList;
        }

    }
}

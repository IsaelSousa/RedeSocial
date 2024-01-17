using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;
using rede_social_infraestructure.Migrations;
using System.Linq;

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
            await this._dbContext.SaveChangesAsync();
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

        public async Task<List<FriendRequestList>> GetPendentUserRequest(string userId, char type)
        {
            if (type == 'S')
            {
                var result = await FriendEF
                    .Where(x => x.ToUserId == userId && !x.IsDeleted)
                    .Join(Logins, a => a.ToUserId, b => b.Id, (a, b) => new { Id = a.Id, UserName = b.UserName })
                    .ToListAsync();

                List<FriendRequestList> friendList = new List<FriendRequestList>();
                foreach (var item in result) friendList.Add(new FriendRequestList(item.Id, item.UserName));
                return friendList;
            }
            else if (type == 'R')
            {
                var result = await FriendEF
                    .Where(x => x.FromUserId == userId && !x.IsDeleted)
                    .Join(Logins, a => a.FromUserId, b => b.Id, (a, b) => new { Id = a.Id, UserName = b.UserName })
                    .ToListAsync();

                List<FriendRequestList> friendList = new List<FriendRequestList>();
                foreach (var item in result) friendList.Add(new FriendRequestList(item.Id, item.UserName));
                return friendList;
            }
            else return null;
        }
    }
}

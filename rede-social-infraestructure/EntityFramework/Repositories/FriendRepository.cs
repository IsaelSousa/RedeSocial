using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_domain.Models.Enum;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        public EFContext _dbContext { get; private set; }
        public DbSet<FriendRequestEF> DbSet { get; set; }

        public FriendRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = this._dbContext.Set<FriendRequestEF>(); ;
        }

        public async Task<bool> CreateInvite(FriendRequestEF friendRequest)
        {
            var data = await this.DbSet.AddAsync(friendRequest);
            if (data == null) return false;
            return true;
        } 

        public async Task<bool> ChangeStatusInvite(FriendRequestEF friendRequest)
        {
            if (friendRequest.Status != FriendRequestStatusEnumConverter.ToChar(FriendStatusEnum.Refused))
            {
                this.DbSet.Update(friendRequest);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<FriendRequestEF> GetPendentRequest(string fromUserId, string toUserId)
        {
            return await this.DbSet.FirstOrDefaultAsync(x => 
            x.FromUserId == fromUserId
            && x.ToUserId == toUserId
            && x.Status == 'P'
            && !x.IsDeleted);
        }

        public async Task<List<FriendRequestEF>> GetPendentUserRequestList(string userId)
        {
            return await this.DbSet.Where(x =>
            x.ToUserId == userId
            && x.Status == 'P'
            && !x.IsDeleted)
                .ToListAsync();
        }
    }
}

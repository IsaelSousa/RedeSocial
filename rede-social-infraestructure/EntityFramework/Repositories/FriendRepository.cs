using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        public EFContext _dbContext { get; private set; }
        public DbSet<FriendsEF> DbSet { get; private set; }

        public async Task<FriendsEF> CreateInvite(FriendsEF friend)
        {
            await this.DbSet.AddAsync(friend);
            await this._dbContext.SaveChangesAsync();
            return friend;
        }

        public async Task<List<FriendsEF>> GetAllFriends(string id)
        {
            var data = await this.DbSet.Where(x => x.UserId == id).ToListAsync();

            if (data == null)
                return null;

            return data;
        }

        public async Task<bool> RemoveAsync(string friendId)
        {
            var user = await this.DbSet.Where(x => x.FriendId == friendId).FirstOrDefaultAsync();
            if (user != null)
            {
                this.DbSet.Remove(user);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }
    }
}

using rede_social_domain.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_domain.Entities.FriendAggregate
{
    public interface IFriendRepository
    {
        public Task<FriendsEF> CreateInvite(FriendsEF friend);
        public Task<List<FriendsEF>> GetAllFriends(string id);
        public Task<bool> RemoveAsync(string friendId);
    }
}

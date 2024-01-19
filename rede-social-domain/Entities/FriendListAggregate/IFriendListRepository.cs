﻿using rede_social_domain.Models.EFModels;

namespace rede_social_domain.Entities.FriendListAggregate
{
    public interface IFriendListRepository
    {
        public Task<List<FriendListEF>> GetAllRegisterOnlyFriend(string userId);
        public Task<FriendListEF> GetFriend(string userId, string toUserId);
        public Task AddFriend(FriendListEF friendList);
        public Task DeleteUser(FriendListEF friendList);
        public Task<List<string>> GetAllFriendList(string userId);
    }
}

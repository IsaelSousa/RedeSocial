using rede_social_domain.Models.EFModels;

namespace rede_social_domain.Entities.FriendAggregate
{
    public interface IFriendRepository
    {
        public Task<bool> CreateInvite(FriendRequestEF friendRequest);
        public Task ChangeStatusInvite(FriendRequestEF friendRequest);
        public Task<FriendRequestEF> GetPendentRequest(string fromUserId, string toUserId);
        public Task<List<FriendRequestList>> GetPendentUserRequest(string userId, char type);
        public Task<FriendRequestEF> GetById(long id);
    }
}

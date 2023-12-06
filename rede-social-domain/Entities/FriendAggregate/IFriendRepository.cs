using rede_social_domain.Models.EFModels;

namespace rede_social_domain.Entities.FriendAggregate
{
    public interface IFriendRepository
    {
        public Task<bool> CreateInvite(FriendRequestEF friendRequest);
        public Task<bool> ChangeStatusInvite(FriendRequestEF friendRequest);
        public Task<FriendRequestEF> GetPendentRequest(string fromUserId, string toUserId);
        public Task<List<FriendRequestEF>> GetPendentUserRequestList(string userId);
    }
}

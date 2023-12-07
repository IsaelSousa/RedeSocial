using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.FriendList.RemoveFriend
{
    public class RemoveFriendRequest : IRequest<Response<bool>>
    {

        public RemoveFriendRequest(string fromUserId, string toUserId)
        {
            this.FromUserId = fromUserId;
            this.ToUserId = toUserId;
        }

        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
    }
}

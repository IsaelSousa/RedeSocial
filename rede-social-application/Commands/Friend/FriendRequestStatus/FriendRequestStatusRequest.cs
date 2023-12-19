using MediatR;
using rede_social_application.Models;
using rede_social_domain.Models.Enum;

namespace rede_social_application.Commands.Friend.AcceptFriend
{
    public class FriendRequestStatusRequest : IRequest<Response<bool>>
    {
        public string Id { get; set; } 
        public string UserName { get; set; }
        public FriendStatusEnum Status { get; set; }

        public FriendRequestStatusRequest(FriendRequestStatusRequest payload)
        {
            this.Id = payload.Id;
            this.UserName = payload.UserName;
            this.Status = payload.Status;
        }
    }
}

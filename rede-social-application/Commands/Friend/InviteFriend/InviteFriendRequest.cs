using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.Friend.InviteFriend
{
    public class InviteFriendRequest : IRequest<Response<bool>>
    {
        public string UserId { get; set; }
        public string FriendUserName { get; set; }
    }
}

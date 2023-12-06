using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.Friend.GetFriend
{
    public class GetFriendRequestListRequest : IRequest<Response<List<FriendListModel>>>
    {
        public string UserId { get; set; }
    }
}

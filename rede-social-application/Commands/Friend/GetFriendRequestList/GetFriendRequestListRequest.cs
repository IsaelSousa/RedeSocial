using MediatR;
using rede_social_application.Models;
using rede_social_application.Models.Enum;

namespace rede_social_application.Commands.Friend.GetFriend
{
    public class GetFriendRequestListRequest : IRequest<Response<List<FriendRequestListModel>>>
    {
        public string UserId { get; set; }
        public GetFriendEnum Type { get; set; }
        public GetFriendRequestListRequest(string userId, GetFriendEnum type)
        {
            this.UserId = userId;
            this.Type = type;
        }
    }
}

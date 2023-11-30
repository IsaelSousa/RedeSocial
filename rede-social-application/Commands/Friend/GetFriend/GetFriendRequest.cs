using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.Friend.GetFriend
{
    public class GetFriendRequest : IRequest<Response<List<FriendsListModel>>>
    {
        public string UserId { get; set; }
        public GetFriendRequest(string userId) 
        {
            this.UserId = userId;
        }

    }
}

using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.FriendList.ListFriend
{
    public class ListFriendRequest : IRequest<Response<List<string>>>
    {
        public string Id { get; set; }

        public ListFriendRequest(string id)
        {
            this.Id = id;
        }
    }
}

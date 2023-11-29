using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.Friend.ListFriends
{
    public class ListFriendsRequest : IRequest<Response<List<FriendsListModel>>>
    {
        public string Id {  get; set; }
    }
}

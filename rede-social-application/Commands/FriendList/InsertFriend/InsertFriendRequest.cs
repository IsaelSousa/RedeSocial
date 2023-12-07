using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.FriendList.InsertFriend
{
    public class InsertFriendRequest : FriendListModel, IRequest<Response<bool>> {}
}

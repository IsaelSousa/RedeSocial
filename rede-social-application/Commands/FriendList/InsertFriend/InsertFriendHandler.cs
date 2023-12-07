using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.FriendList.InsertFriend
{
    public class InsertFriendHandler : IRequestHandler<InsertFriendRequest, Response<bool>>
    {
        public Task<Response<bool>> Handle(InsertFriendRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

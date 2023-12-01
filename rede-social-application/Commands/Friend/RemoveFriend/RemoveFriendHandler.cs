using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.Friend.RemoveFriend
{
    public class RemoveFriendHandler : IRequestHandler<RemoveFriendRequest, Response<bool>>
    {
        public Task<Response<bool>> Handle(RemoveFriendRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

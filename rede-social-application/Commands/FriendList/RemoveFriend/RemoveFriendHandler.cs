using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendListAggregate;

namespace rede_social_application.Commands.FriendList.RemoveFriend
{
    public class RemoveFriendHandler : IRequestHandler<RemoveFriendRequest, Response<bool>>
    {

        private readonly IFriendListRepository friendListRepository;
        public RemoveFriendHandler(IFriendListRepository friendListRepository)
        {
            this.friendListRepository = friendListRepository;
        }

        public async Task<Response<bool>> Handle(RemoveFriendRequest request, CancellationToken cancellationToken)
        {
            var data = await friendListRepository.GetFriend(request.FromUserId, request.ToUserId);

            if (data == null) return new Response<bool>(false).AddMessage("Friend not found!");

            await friendListRepository.DeleteUser(data);

            return new Response<bool>(true).AddMessage("Friend removed!");
        }
    }
}

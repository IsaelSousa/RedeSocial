using MediatR;
using Microsoft.IdentityModel.Tokens;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendAggregate;

namespace rede_social_application.Commands.Friend.RemoveFriend
{
    public class RemoveFriendHandler : IRequestHandler<RemoveFriendRequest, Response<bool>>
    {
        private readonly IFriendRepository friendRepository;
        public RemoveFriendHandler(IFriendRepository friendRepository)
        {
            this.friendRepository = friendRepository;
        }

        public async Task<Response<bool>> Handle(RemoveFriendRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendRepository.GetUserFriend(request.Id, request.UserName);

            if (data.IsNullOrEmpty()) return new Response<bool>(false).AddMessage("Friend not found!");

            data.ForEach(async x => await this.friendRepository.RemoveAsync(x.UserId, x.FriendUserName));

            return new Response<bool>(true).AddMessage("Friend removed!");
        }
    }
}

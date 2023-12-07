using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendListAggregate;

namespace rede_social_application.Commands.FriendList.InsertFriend
{
    public class InsertFriendHandler : IRequestHandler<InsertFriendRequest, Response<bool>>
    {
        private readonly IFriendListRepository friendListRepository;

        public InsertFriendHandler(IFriendListRepository friendListRepository)
        {
            this.friendListRepository = friendListRepository;
        }

        public async Task<Response<bool>> Handle(InsertFriendRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendListRepository.GetFriend(request.FriendId, request.UserId);

            if (data != null) await this.friendListRepository.DeleteUser(data); 

            await this.friendListRepository.AddFriend(data);

            return new Response<bool>(true)
                .AddMessage("Insert with success!");
        }
    }
}

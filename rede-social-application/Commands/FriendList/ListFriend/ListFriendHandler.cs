using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendListAggregate;

namespace rede_social_application.Commands.FriendList.ListFriend
{
    public class ListFriendHandler : IRequestHandler<ListFriendRequest, Response<List<string>>>
    {
        private readonly IFriendListRepository friendListRepository;

        public ListFriendHandler(IFriendListRepository friendListRepository)
        {
            this.friendListRepository = friendListRepository;
        }

        public async Task<Response<List<string>>> Handle(ListFriendRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendListRepository.GetAllFriendList(request.Id);

            if (data == null) return new Response<List<string>>(false).AddMessage("");

            return new Response<List<string>>(data);

        }
    }
}

using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_application.Models.Enum;
using rede_social_domain.Entities.FriendAggregate;

namespace rede_social_application.Commands.Friend.GetFriend
{
    public class GetFriendRequestListHandler : IRequestHandler<GetFriendRequestListRequest, Response<List<FriendRequestListModel>>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IMapper mapper;

        public GetFriendRequestListHandler(IFriendRepository friendRepository, IMapper mapper)
        {
            this.friendRepository = friendRepository;
            this.mapper = mapper;
        }

        public async Task<Response<List<FriendRequestListModel>>> Handle(GetFriendRequestListRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendRepository.GetPendentUserRequest(request.UserId, GetFriendRequestEnum.ToChar(request.Type));

            if (data == null) return new Response<List<FriendRequestListModel>>(false).AddMessage("Error to get pendent friend request!");

            return new Response<List<FriendRequestListModel>>(this.mapper.Map<List<FriendRequestListModel>>(data));
        }
    }
}

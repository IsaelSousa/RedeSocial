using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendAggregate;

namespace rede_social_application.Commands.Friend.GetFriend
{
    public class GetFriendRequestListHandler : IRequestHandler<GetFriendRequestListRequest, Response<List<FriendRequestModel>>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IMapper mapper;

        public GetFriendRequestListHandler(IFriendRepository friendRepository, IMapper mapper)
        {
            this.friendRepository = friendRepository;
            this.mapper = mapper;
        }

        public async Task<Response<List<FriendRequestModel>>> Handle(GetFriendRequestListRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendRepository.GetPendentUserRequestList(request.UserId);

            if (data == null) return new Response<List<FriendRequestModel>>(false).AddMessage("Error to get pendent friend request!");

            return new Response<List<FriendRequestModel>>(this.mapper.Map<List<FriendRequestModel>>(data));
        }
    }
}

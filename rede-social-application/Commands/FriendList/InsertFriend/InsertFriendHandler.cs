using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.FriendListAggregate;
using rede_social_domain.Models.EFModels;

namespace rede_social_application.Commands.FriendList.InsertFriend
{
    public class InsertFriendHandler : IRequestHandler<InsertFriendRequest, Response<bool>>
    {
        private readonly IFriendListRepository friendListRepository;
        private readonly IMapper mapper;

        public InsertFriendHandler(IFriendListRepository friendListRepository, IMapper mapper)
        {
            this.friendListRepository = friendListRepository;
            this.mapper = mapper;
        }

        public async Task<Response<bool>> Handle(InsertFriendRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendListRepository.GetFriend(request.UserId, request.FriendId);

            if (data != null) await this.friendListRepository.DeleteUser(data);

            var map = this.mapper.Map<FriendListEF>(request);

            await this.friendListRepository.AddFriend(map);

            return new Response<bool>(true)
                .AddMessage("Insert with success!");
        }
    }
}

using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.FriendAggregate;

namespace rede_social_application.Commands.Friend.GetRequestInvite
{
    public class GetRequestInviteHandler : IRequestHandler<GetRequestInviteRequest, Response<List<FriendsListModel>>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IAuthRepository authRepository;
        private readonly IMapper mapper;
        public GetRequestInviteHandler(IFriendRepository friendRepository, IAuthRepository authRepository, IMapper mapper) 
        {
            this.friendRepository = friendRepository;
            this.authRepository = authRepository;
            this.mapper = mapper;
        }

        public async Task<Response<List<FriendsListModel>>> Handle(GetRequestInviteRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendRepository.VerifyExistsInviteUser(request.Id);

            if (data == null) return null;

            var resp = this.mapper.Map<List<FriendsListModel>>(data);

            return new Response<List<FriendsListModel>>(resp, true); 
        }
    }
}

using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_application.Models.Enum;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.FriendAggregate;

namespace rede_social_application.Commands.Friend.PendentInvite
{
    public class PendentInviteHandler : IRequestHandler<PendentInviteRequest, Response<InviteAndReceivedModel>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IAuthRepository authRepository;
        private readonly IMapper mapper;

        public PendentInviteHandler(IFriendRepository friendRepository, IAuthRepository authRepository, IMapper mapper)
        {
            this.friendRepository = friendRepository;
            this.authRepository = authRepository;
            this.mapper = mapper;
        }

        public async Task<Response<List<InviteAndReceivedModel>>> Handle(PendentInviteRequest request, CancellationToken cancellationToken)
        {
            var user = await this.authRepository.GetUserName(request.UserName);

            if (request.Pendent == PendentEnum.Invited)
            {
                var resp = await this.friendRepository.GetPendentRequest(request.Id, user.Id);
                return new Response<List<InviteAndReceivedModel>>("").AddMessage();

            }
            else if (request.Pendent == PendentEnum.Received)
            {
                var resp = await this.friendRepository.GetPendentRequest(request.Id, user.Id);
            }
            else return new Response<List<InviteAndReceivedModel>>(false).AddMessage($"Error to list of {request.Pendent}"); 
        }
    }
}

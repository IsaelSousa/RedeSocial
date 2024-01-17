using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_domain.Models.EFModels;

namespace rede_social_application.Commands.Friend.InviteFriend
{
    public class InviteFriendHandler : IRequestHandler<InviteFriendRequest, Response<bool>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IAuthRepository authRepository;

        public InviteFriendHandler(IFriendRepository friendRepository, IAuthRepository authRepository)
        {
            this.friendRepository = friendRepository;
            this.authRepository = authRepository;
        }

        public async Task<Response<bool>> Handle(InviteFriendRequest request, CancellationToken cancellationToken)
        {
            var friendName = await this.authRepository.GetUserName(request.FriendUserName);

            var verifyExistsInvite = await this.friendRepository.GetPendentRequest(request.UserId, friendName.Id);
            if (verifyExistsInvite != null)
                return new Response<bool>(true).AddMessage("This invitation has already been sent.");

            var status = await this.friendRepository.CreateInvite(new FriendRequestEF(request.UserId, friendName.Id));

            if (status == false) return new Response<bool>(false)
                    .AddMessage("Failed to create invite!");

            return new Response<bool>(true)
                .AddMessage("Success to create invite!");
        }
    }
}

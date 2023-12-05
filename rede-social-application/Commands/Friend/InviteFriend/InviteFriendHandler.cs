using AutoMapper;
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

            FriendRequestEF friend = new FriendRequestEF();
            friend.FromUserId = request.UserId;
            friend.ToUserId = friendName.Id;
            var status = await this.friendRepository.CreateInvite(friend);
            if (status == false) return new Response<bool>(false).AddMessage("Failed to create invite!");
            return new Response<bool>(true).AddMessage("Success to create invite!");
        }
    }
}

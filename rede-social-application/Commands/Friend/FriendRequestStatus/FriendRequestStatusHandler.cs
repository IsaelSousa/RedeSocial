using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_domain.Models.Enum;

namespace rede_social_application.Commands.Friend.AcceptFriend
{
    public class FriendRequestStatusHandler : IRequestHandler<FriendRequestStatusRequest, Response<bool>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IAuthRepository authRepository;

        public FriendRequestStatusHandler(IFriendRepository friendRepository, IAuthRepository authRepository)
        {
            this.friendRepository = friendRepository;
            this.authRepository = authRepository;
        }

        public async Task<Response<bool>> Handle(FriendRequestStatusRequest request, CancellationToken cancellationToken)
        {
            var user = await this.authRepository.GetUserName(request.UserName);
            var data = await this.friendRepository.GetPendentRequest(request.Id, user.Id);
            data.Status = FriendRequestStatusEnumConverter.ToChar(request.Status);
            await this.friendRepository.ChangeStatusInvite(data);
            return new Response<bool>(true).AddMessage("Accepted with success!");
        }
    }
}

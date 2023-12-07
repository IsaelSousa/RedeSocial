using MediatR;
using rede_social_application.Commands.FriendList.InsertFriend;
using rede_social_application.Commands.FriendList.RemoveFriend;
using rede_social_application.Models;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_domain.Entities.FriendListAggregate;
using rede_social_domain.Models.EFModels;
using rede_social_domain.Models.Enum;

namespace rede_social_application.Commands.Friend.AcceptFriend
{
    public class FriendRequestStatusHandler : IRequestHandler<FriendRequestStatusRequest, Response<bool>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IAuthRepository authRepository;
        private readonly IMediator mediator;

        public FriendRequestStatusHandler(IFriendRepository friendRepository, IAuthRepository authRepository, IMediator mediator)
        {
            this.friendRepository = friendRepository;
            this.authRepository = authRepository;
            this.mediator = mediator;
        }

        public async Task<Response<bool>> Handle(FriendRequestStatusRequest request, CancellationToken cancellationToken)
        {
            var user = await this.authRepository.GetUserName(request.UserName);

            var data = await this.friendRepository.GetPendentRequest(request.Id, user.Id);

            data.Status = FriendRequestStatusEnumConverter.ToChar(request.Status);

            await this.friendRepository.ChangeStatusInvite(data);

            if (data.Status == FriendRequestStatusEnumConverter.ToChar(FriendStatusEnum.Removed))
            {
                await this.mediator.Send(new RemoveFriendRequest(request.Id, user.Id));
            }

            if (data.Status == FriendRequestStatusEnumConverter.ToChar(FriendStatusEnum.Accepted))
            {
                await this.mediator.Send(new InsertFriendRequest(request.Id, user.Id));
            }

            return new Response<bool>(true).AddMessage("Accepted with success!");
        }
    }
}

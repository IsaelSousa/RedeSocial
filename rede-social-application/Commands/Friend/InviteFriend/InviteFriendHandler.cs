using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_domain.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.InviteFriend
{
    public class InviteFriendHandler : IRequestHandler<InviteFriendRequest, Response<bool>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IAuthRepository authRepository;
        private readonly IMapper mapper;

        public InviteFriendHandler(IFriendRepository friendRepository, IAuthRepository authRepository, IMapper mapper)
        {
            this.friendRepository = friendRepository;
            this.authRepository = authRepository;
            this.mapper = mapper;
        }

        public async Task<Response<bool>> Handle(InviteFriendRequest request, CancellationToken cancellationToken)
        {
            var friend = await authRepository.GetUserName(request.FriendUserName);
            var UserById = await authRepository.GetUserById(request.UserId);

            if (friend.Id == request.UserId) return new Response<bool>(false).AddMessage("You cannot use your username!");

            if (friend == null) return new Response<bool>(false).AddMessage("Friend not found!");

            FriendsModel friendsModel = new FriendsModel();
            friendsModel.FriendAccept = true;
            friendsModel.UserId = request.UserId;
            friendsModel.UserName = UserById.UserName;
            friendsModel.FriendId = friend.Id;
            friendsModel.FriendUserName = friend.UserName;

            var invite = this.mapper.Map<FriendsEF>(friendsModel);

            var friendExists = await friendRepository.VerifyExistsInvite(invite);

            if (friendExists != null) return new Response<bool>(false).AddMessage("Invitation already sent!");

            await friendRepository.CreateInvite(invite);

            friendsModel.FriendAccept = false;
            friendsModel.UserId = friend.Id;
            friendsModel.UserName = friend.UserName;
            friendsModel.FriendUserName = UserById.UserName;
            friendsModel.FriendId = request.UserId;

            var reverseInvite = this.mapper.Map<FriendsEF>(friendsModel);
            await friendRepository.CreateInvite(reverseInvite);

            return new Response<bool>(true);
        }
    }
}

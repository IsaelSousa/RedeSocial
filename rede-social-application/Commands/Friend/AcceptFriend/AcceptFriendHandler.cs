using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.FriendAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.AcceptFriend
{
    public class AcceptFriendHandler : IRequestHandler<AcceptFriendRequest, Response<bool>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IAuthRepository authRepository;

        public AcceptFriendHandler(IFriendRepository friendRepository)
        {
            this.friendRepository = friendRepository;
        }

        public async Task<Response<bool>> Handle(AcceptFriendRequest request, CancellationToken cancellationToken)
        {
            var user = await this.authRepository.GetUserName(request.UserName);

            var data = await this.friendRepository.GetPendentRequest(request.Id, user.Id);
        }
    }
}

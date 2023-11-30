using MediatR;
using rede_social_application.Models;
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

        public AcceptFriendHandler(IFriendRepository friendRepository)
        {
            this.friendRepository = friendRepository;
        }

        public async Task<Response<bool>> Handle(AcceptFriendRequest request, CancellationToken cancellationToken)
        {
            var data = await this.friendRepository.AcceptInvite(request.Id, request.UserName);

            if (!data) return new Response<bool>("Friend request not accept!", false);

            if (data) return new Response<bool>("Friend request accepted!", true);

            return new Response<bool>(false);
        }
    }
}

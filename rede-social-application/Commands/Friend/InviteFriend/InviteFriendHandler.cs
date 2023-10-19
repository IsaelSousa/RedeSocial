using MediatR;
using rede_social_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.InviteFriend
{
    public class InviteFriendHandler : IRequestHandler<InviteFriendRequest, Response<bool>>
    {
        public Task<Response<bool>> Handle(InviteFriendRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

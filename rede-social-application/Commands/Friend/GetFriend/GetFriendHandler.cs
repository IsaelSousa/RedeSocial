using MediatR;
using rede_social_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.GetFriend
{
    public class GetFriendHandler : IRequestHandler<GetFriendRequest, Response<List<FriendsListModel>>>
    {
        public Task<Response<List<FriendsListModel>>> Handle(GetFriendRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using MediatR;
using rede_social_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.GetRequestInvite
{
    public class GetRequestInviteRequest : IRequest<Response<List<FriendsListModel>>>
    {
        public string Id { get; set; }
    }
}

using MediatR;
using rede_social_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.RemoveFriend
{
    public class RemoveFriendRequest : IRequest<Response<bool>>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}

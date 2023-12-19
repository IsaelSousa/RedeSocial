using MediatR;
using rede_social_application.Models;
using rede_social_application.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Friend.PendentInvite
{
    public class PendentInviteRequest : IRequest<Response<InviteAndReceivedModel>>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public PendentEnum Pendent { get; set; }
    }
}

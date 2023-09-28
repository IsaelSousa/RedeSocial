using MediatR;
using rede_social_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Profile.GetProfile
{
    public class GetProfileRequest : IRequest<Response>
    {
        public long Id { get; set; }
    }
}

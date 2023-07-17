using MediatR;
using rede_social_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Post.InsertPost
{
    public class InsertPostRequest : IRequest<Response>
    {
        public string UserId { get; set; }
        public string PostMessage { get; set; }
        public string Image { get; set; }
    }
}

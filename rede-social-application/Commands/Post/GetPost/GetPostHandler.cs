using MediatR;
using rede_social_application.Commands.Post.InsertPost;
using rede_social_application.Models;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Post.GetPost
{
    public class GetPostHandler : IRequestHandler<GetPostRequest, Response>
    {
        private readonly EFContext _context;
        public GetPostHandler(EFContext context)
        {
            this._context = context;
        }
        public async Task<Response> Handle(GetPostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<PostPerUser> a = new List<PostPerUser>();

                PostPerUser b = new PostPerUser()
                { 
                    Image = "a",
                    PostMessage = "a",
                    UserId = "a"
                };

                a.Add(b);

                return new Response(a, true);
            }
            catch (Exception ex)
            {
                return new Response("Error to create post", false);
            }
        }

    }
}

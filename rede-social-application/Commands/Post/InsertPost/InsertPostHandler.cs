using MediatR;
using Microsoft.IdentityModel.Tokens;
using rede_social_application.Commands.Auth.Login;
using rede_social_application.Models;
using rede_social_application.Services;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Post.InsertPost
{
    public class InsertPostHandler : IRequestHandler<InsertPostRequest, Response>
    {
        private readonly EFContext _context;
        public InsertPostHandler(EFContext context)
        {
            this._context = context;
        }
        public async Task<Response> Handle(InsertPostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                rede_social_domain.Models.EFModels.Post postModel = new rede_social_domain.Models.EFModels.Post()
                {
                    UserId = request.UserId,
                    PostMessage = request.PostMessage,
                    Image = request.Image.IsNullOrEmpty() ? "" : request.Image,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                };

                _context.Post.Add(postModel);
                await _context.SaveChangesAsync();

                return new Response("Ok", true);
            }
            catch
            {
                return new Response("Error to create post", false);
            }
        }
    }
}

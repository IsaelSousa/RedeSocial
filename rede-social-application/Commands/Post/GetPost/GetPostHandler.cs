﻿using MediatR;
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

                var data = _context.Post
                    .Join(_context.Logins,
                        post => post.UserId,
                        user => user.Id,
                        (post, user) => new
                        {
                            PostId = post.Id,
                            PostImage = post.Image,
                            PostMsg = post.PostMessage,
                            PostCreatedAt = post.CreatedAt,
                            PostCreatedBy = user.FirstName + " " + user.LastName,
                        }
                    )
                    .OrderByDescending(d => d.PostCreatedAt)
                    .ToList();

                return new Response(data, true);
            }
            catch (Exception ex)
            {
                return new Response("Error to create post", false);
            }
        }

    }
}

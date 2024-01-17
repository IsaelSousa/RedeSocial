using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.PostAggregate;
using rede_social_infraestructure.EntityFramework.Context;
using System.Collections.Generic;

namespace rede_social_application.Commands.Post.GetPost
{
    public class GetPostHandler : IRequestHandler<GetPostRequest, Response<List<PostModel>>>
    {
        private readonly EFContext _context;
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;
        public GetPostHandler(EFContext context, IPostRepository postRepository, IMapper mapper)
        {
            this._context = context;
            this.postRepository = postRepository;
            this.mapper = mapper;

        }
        public async Task<Response<List<PostModel>>> Handle(GetPostRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var data = await postRepository.GetPostAsync();

                var map = this.mapper.Map<List<PostModel>>(data);

                return new Response<List<PostModel>>(map, true);
            }
            catch
            {
                return new Response<List<PostModel>>("Error to create post", false);
            }
        }

    }
}

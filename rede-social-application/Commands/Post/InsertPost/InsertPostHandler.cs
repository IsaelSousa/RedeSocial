using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.PostAggregate;
using rede_social_domain.Models.EFModels;


namespace rede_social_application.Commands.Post.InsertPost
{
    public class InsertPostHandler : IRequestHandler<InsertPostRequest, Response<string>>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public InsertPostHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<Response<string>> Handle(InsertPostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = this.mapper.Map<PostEF>(request);

                postRepository.InsertPost(data);

                return new Response<string>("Ok", true);
            }
            catch
            {
                return new Response<string>("Error to create post", false);
            }
        }
    }
}

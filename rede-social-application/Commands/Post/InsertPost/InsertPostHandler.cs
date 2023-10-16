using AutoMapper;
using MediatR;
using rede_social_application.Models;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Entities.PostAggregate;
using rede_social_domain.Models.EFModels;


namespace rede_social_application.Commands.Post.InsertPost
{
    public class InsertPostHandler : IRequestHandler<InsertPostRequest, Response<string>>
    {
        private readonly IPostRepository postRepository;
        private readonly IAuthRepository authRepository;
        private readonly IMapper mapper;

        public InsertPostHandler(IPostRepository postRepository, IAuthRepository authRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.authRepository = authRepository;
            this.mapper = mapper;
        }

        public async Task<Response<string>> Handle(InsertPostRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await authRepository.GetUserById(request.UserId);

                request.FirstName = user.FirstName;

                var data = this.mapper.Map<PostEF>(request);

                if (request.Image == null)
                    data.Image = "";


                await postRepository.InsertPost(data);

                return new Response<string>("Ok", true);
            }
            catch (Exception ex)
            {
                return new Response<string>("Error to create post", false);
            }
        }
    }
}

using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.Post.InsertPost
{
    public class InsertPostRequest : PostModel, IRequest<Response<string>> {}
}

using MediatR;
using rede_social_application.Models;

namespace rede_social_application.Commands.Post.InsertPost
{
    public class InsertPostRequest : PostModel, IRequest<Response<string>>
    {
        public InsertPostRequest(string id, string userId, string postMessage, string image, DateTime createdAt, DateTime lastupdated) : base(id, userId, postMessage, image, createdAt, lastupdated)
        {
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rede_social_application.Commands.Auth.Register;
using rede_social_application.Commands.Post.GetPost;
using rede_social_application.Commands.Post.InsertPost;
using rede_social_application.Models;
using rede_social_application.Services;
using System.Text;

namespace rede_social_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response> InsertPost()
        {
            var body = String.Empty;
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            Dictionary<string, string> deserializedToken = Token.Deserialize(token);

            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                body = await reader.ReadToEndAsync();

            InsertPostRequest data = EncryptionHelper.DecryptData<InsertPostRequest>(body);
            data.UserId = deserializedToken["Id"];
            return await this._mediator.Send(data);
        }

        [HttpGet("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<Response> GetPost()
            => await this._mediator.Send(new GetPostRequest());
    }
}

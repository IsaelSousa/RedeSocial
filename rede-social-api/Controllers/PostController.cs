using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rede_social_application.Commands.Auth.Register;
using rede_social_application.Commands.Post.InsertPost;
using rede_social_application.Models;
using rede_social_application.Services;
using System.Text;

namespace rede_social_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [Authorize]
        public async Task<Response> InsertPost()
        {
            var body = String.Empty;
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                body = await reader.ReadToEndAsync();

            InsertPostRequest data = EncryptionHelper.DecryptData<InsertPostRequest>(body);
            return await this._mediator.Send(data);
        }
    }
}

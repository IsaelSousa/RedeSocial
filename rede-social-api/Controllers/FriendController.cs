using MediatR;
using Microsoft.AspNetCore.Mvc;
using rede_social_application.Models;

namespace rede_social_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public Task<Response<string>> List()
        {
            return null;
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public Task<Response<string>> Invite()
        {
            return null;
        }
    }
}

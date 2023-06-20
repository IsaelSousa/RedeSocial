using MediatR;
using Microsoft.AspNetCore.Mvc;
using rede_social_application.Commands.Auth.Login;
using rede_social_application.Commands.Auth.Register;

namespace rede_social_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost("api/[action]")]
        public async Task<string> Login(LoginRequest request)
            => await _mediator.Send(request);

        [HttpPost("api/[action]")]
        public async Task<string> Register(RegisterRequest request)
            => await _mediator.Send(request);

    }
}
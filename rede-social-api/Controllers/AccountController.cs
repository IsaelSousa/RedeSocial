using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rede_social_application.Commands.Auth.Login;
using rede_social_application.Commands.Auth.Register;
using rede_social_application.Models;
using rede_social_application.Services;
using rede_social_domain.Models.EFModels;
using System.Text;

namespace rede_social_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<UserTokenModel>> Login()
        {
            var body = String.Empty;
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                body = await reader.ReadToEndAsync();

            LoginRequest data = EncryptionHelper.DecryptData<LoginRequest>(body);
            return await this._mediator.Send(data);
        }

        [HttpPost("[action]")]
        [Consumes("text/plain")]
        [Produces("application/json")]
        public async Task<Response<ApplicationUser>> Register()
        {
            try
            {
                var body = String.Empty;
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                    body = await reader.ReadToEndAsync();

                RegisterRequest data = EncryptionHelper.DecryptData<RegisterRequest>(body);
                return await this._mediator.Send(data);
            }
            catch (Exception ex)
            {
                return new Response<ApplicationUser>("Error in register user", false);
            }
        }

        [HttpGet("[action]")]
        [Produces("application/json")]
        [Authorize]
        public async Task<Response<DateTime>> ValidationToken()
        {
            return new Response<DateTime>(DateTime.UtcNow.ToString(), true);
        }

    }
}
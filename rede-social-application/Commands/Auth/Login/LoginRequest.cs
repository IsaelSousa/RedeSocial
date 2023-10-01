using MediatR;
using rede_social_application.Models;
using rede_social_domain.Models;

namespace rede_social_application.Commands.Auth.Login
{
    public class LoginRequest : IRequest<Response<UserTokenModel>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

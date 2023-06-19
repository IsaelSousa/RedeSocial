using MediatR;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_application.Commands.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, string>
    {
        private readonly EFContext _context;
        public LoginHandler(EFContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            LoginModel loginModel = new LoginModel()
            {
                CreatedAt = DateTime.UtcNow,
            };
            return "";
        }
    }
}

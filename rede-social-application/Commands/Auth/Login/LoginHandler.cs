using MediatR;
using Microsoft.AspNetCore.Identity;
using rede_social_application.Models;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_application.Commands.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, string>
    {
        private readonly EFContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoginHandler(EFContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }
        public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            
            if (user == null)
                return "Usuário não existe";

            var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isValidPassword)
                return "Senha inválida";

            return "Login efetuado";

        }
    }
}

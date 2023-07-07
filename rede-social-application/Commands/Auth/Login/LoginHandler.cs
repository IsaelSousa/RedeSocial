using MediatR;
using Microsoft.AspNetCore.Identity;
using rede_social_application.Models;
using rede_social_application.Services;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_application.Commands.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, Response>
    {
        private readonly EFContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoginHandler(EFContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }
        public async Task<Response> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return new Response("User not exists", false);

                var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!isValidPassword)
                    return new Response("Invalid Password", false);

                return new Response(Token.GenerateToken(user.Id, user.UserName, user.Email), true);
            }
            catch (Exception ex)
            {
                return new Response("Error in login", false);
            }
        }
    }
}

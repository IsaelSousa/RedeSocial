using MediatR;
using Microsoft.AspNetCore.Identity;
using rede_social_application.Models;
using rede_social_application.Services;
using rede_social_domain.Models;
using rede_social_domain.Models.EFModels;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_application.Commands.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, Response<UserToken>>
    {
        private readonly EFContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoginHandler(EFContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }
        public async Task<Response<UserToken>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                    return new Response<UserToken>("User not exists", false);

                var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!isValidPassword)
                    return new Response<UserToken>("Invalid Password", false);

                return new Response<UserToken>(Token.GenerateToken(user.Id, user.UserName, user.Email), true);
            }
            catch (Exception ex)
            {
                return new Response<UserToken>("Error in login", false);
            }
        }
    }
}

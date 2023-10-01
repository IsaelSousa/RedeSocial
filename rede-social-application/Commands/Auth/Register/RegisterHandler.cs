using MediatR;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;
using Microsoft.AspNetCore.Identity;
using rede_social_application.Models;
using Newtonsoft.Json;
using rede_social_domain.Models.EFModels;

namespace rede_social_application.Commands.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, Response<ApplicationUser>>
    {
        private readonly EFContext _context;
        private readonly IAuthRepository _authRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterHandler(EFContext context, IAuthRepository authRepository, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._authRepository = authRepository;
            this._userManager = userManager;
        }

        public async Task<Response<ApplicationUser>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            ApplicationUser registerModel = new ApplicationUser(
                request.Email,
                request.EmailConfirmed,
                request.UserName,
                request.UserName,
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.PhoneNumberConfirmed,
                request.TwoFactorEnabled
                );

            var result = await _userManager.CreateAsync(registerModel, request.Password);

            if (result.Succeeded)
                return new Response<ApplicationUser>("Registered with success!", true);
            else
                return new Response<ApplicationUser>(result.Errors.ToString(), false);
        }
    }
}

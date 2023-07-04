using MediatR;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;
using Microsoft.AspNetCore.Identity;
using rede_social_application.Models;
using Newtonsoft.Json;

namespace rede_social_application.Commands.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, Response>
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

        public async Task<Response> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            ApplicationUser registerModel = new ApplicationUser()
            {
                Email = request.Email,
                EmailConfirmed = request.EmailConfirmed,
                UserName = request.UserName,
                NormalizedUserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                PhoneNumberConfirmed = request.PhoneNumberConfirmed,
                TwoFactorEnabled = request.TwoFactorEnabled
            };

            var result = await _userManager.CreateAsync(registerModel, request.Password);

            if (result.Succeeded)
                return new Response("Registrado com sucesso", true);
            else
                return new Response(result.Errors, false);
        }
    }
}

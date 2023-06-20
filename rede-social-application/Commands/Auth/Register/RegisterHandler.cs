using MediatR;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;
using rede_social_infraestructure.EntityFramework.Repositories;

namespace rede_social_application.Commands.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, string>
    {
        private readonly EFContext _context;
        private readonly IAuthRepository _authRepository;
        public RegisterHandler(EFContext context, IAuthRepository authRepository)
        {
            _context = context;
            _authRepository = authRepository;
        }


        public async Task<string> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            RegisterModel registerModel = new RegisterModel();
            registerModel.UserName = request.UserName;
            registerModel.Password = request.Password;
            registerModel.Name = request.Name;
            registerModel.Email = request.Email;
            registerModel.PhoneNumber = request.PhoneNumber;

            _authRepository.RegisterUser(registerModel);
            return "Usuário registrado.";
        }
    }
}

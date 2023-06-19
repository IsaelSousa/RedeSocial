using MediatR;
using rede_social_application.Commands.Auth.Login;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, string>
    {
        private readonly EFContext _context;
        public RegisterHandler(EFContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            return "";
        }
    }
}

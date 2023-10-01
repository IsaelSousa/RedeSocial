using MediatR;
using Microsoft.AspNet.Identity;
using rede_social_application.Models;
using rede_social_domain.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Auth.Register
{
    public class RegisterRequest : IRequest<Response<ApplicationUser>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }

    }
}

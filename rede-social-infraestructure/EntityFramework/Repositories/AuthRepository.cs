using rede_social_domain.Entities;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class AuthRepository
    {
        EFContext _dbContext;

        public AuthRepository(EFContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public void ValidationAuth(string userName, string password)
        {
            _dbContext.Logins.Where(x => x.UserName == userName);
        }

        public async Task RegisterUser(RegisterModel register)
        {
            Login login = new Login();
            login.Id = Guid.NewGuid();
            login.Name = register.UserName;
            login.Password = register.Password;
            login.Email = register.Email;
            login.PhoneNumber = register.PhoneNumber;
            login.UserName = register.UserName;

            _dbContext.Logins.AddAsync(login);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using rede_social_domain.Entities;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_domain.Models;
using rede_social_infraestructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_infraestructure.EntityFramework.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        EFContext _dbContext;

        public AuthRepository(EFContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public async Task RegisterUser(RegisterModel register)
        {
            try
            {
                Login login = new Login();
                login.Name = register.UserName;
                login.Password = register.Password;
                login.Email = register.Email;
                login.PhoneNumber = register.PhoneNumber;
                login.UserName = register.UserName;
                login.CreatedAt = DateTime.UtcNow;

                _dbContext.Logins.Add(login);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ValidateUserRegister(string userName)
        {
            List<Login> list = await _dbContext.Logins
                .Where(x => x.UserName == userName).ToListAsync();

            bool validate = false;

            if (list.Count > 0)
                validate = true;
            return validate;
        }
    }
}

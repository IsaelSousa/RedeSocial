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
        public EFContext _dbContext;

        public AuthRepository(EFContext dbContext) 
        {
            this._dbContext = dbContext;
        }

    }
}

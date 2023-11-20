using rede_social_domain.Models;
using rede_social_domain.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_domain.Entities.AuthAggregate
{
    public interface IAuthRepository
    {
        public Task<ApplicationUser> GetUserById(string id);
        public Task<ApplicationUser> GetUserName(string userName);
    }
}

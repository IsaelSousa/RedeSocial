using rede_social_domain.Entities.AuthAggregate;
using rede_social_infraestructure.EntityFramework.Context;

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

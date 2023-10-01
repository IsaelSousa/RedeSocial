using rede_social_domain.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_domain.Entities.PostAggregate
{
    public interface IPostRepository
    {
        public Task<List<PostEF>> GetPostAsync();
        public void InsertPost(PostEF post);

    }
}

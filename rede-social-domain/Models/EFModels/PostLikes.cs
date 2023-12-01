using rede_social_domain.Models.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_domain.Models.EFModels
{
    public class PostLikes : StandardModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

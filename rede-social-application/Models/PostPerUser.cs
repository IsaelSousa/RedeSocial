using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Models
{
    public class PostPerUser
    {
        public string UserId { get; set; }
        public string PostMessage { get; set; }
        public string Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Models
{
    public class UserTokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Models
{
    public class Response
    {
        public dynamic message { get; set; }
        public bool status { get; set; } = false;
    
        public Response(dynamic message, bool status)
        {
            this.message = message;
            this.status = status;
        }
    }
}

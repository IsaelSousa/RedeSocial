using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Models
{
    public class Response<T>
    {
        public dynamic message { get; set; }
        public T data { get; set; }
        public bool status { get; set; } = false;

        public Response(T data, bool status)
        {
            this.data = data;
            this.status = status;
        }

        public Response(string message, bool status)
        {
            this.message = message;
            this.status = status;
        }

        public Response(bool status)
        {
            this.message = "";
            this.status = status;
        }

        public Response<T> AddMessage(string message)
        {
            this.message = message;
            return this;
        }
    }

}

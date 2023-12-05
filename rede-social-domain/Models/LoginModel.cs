using rede_social_domain.Models.Standard;
using System;

namespace rede_social_domain.Models
{
    public class LoginModel : StandardModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

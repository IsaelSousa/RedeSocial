using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_domain.Models.EFModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int AccessFailedCount { get; set; }

        public ApplicationUser(
            string email,
            bool emailConfirmed,
            string userName,
            string normalizedUserName,
            string firstName,
            string lastName,
            string phoneNumber,
            bool phoneNumberConfirmed,
            bool twoFactorEnabled) 
        {
            this.Email = email;
            this.EmailConfirmed = emailConfirmed;
            this.UserName = userName;
            this.NormalizedUserName = normalizedUserName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.PhoneNumberConfirmed = phoneNumberConfirmed;
            this.TwoFactorEnabled = twoFactorEnabled;

        }

    }
}

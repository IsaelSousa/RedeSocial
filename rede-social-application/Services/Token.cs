using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using rede_social_application.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Identity;

namespace rede_social_application.Services
{
    public static class Token
    {
        private static string keyJwt = "asd123sdesfsd4554ghmkl675uyj45456k4323476767hthgvhgj";
        public static UserToken GenerateToken(string id, string userName, string email)
        {
            var claims = new[]
            {
                new Claim("Id", id),
                new Claim("UserName", userName),
                new Claim("Email", email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyJwt));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        public static Dictionary<string, string> Deserialize(string tokenParater)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(keyJwt);
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var claims = handler.ValidateToken(tokenParater, validations, out var tokenSecure);
                var id = claims.FindFirst("id")?.Value;
                var email = claims.FindFirst("email")?.Value;
                var userName = claims.FindFirst("UserName")?.Value;

                Dictionary<string, string> obj = new Dictionary<string, string>();

                obj.Add("Id", id);
                obj.Add("Email", email);
                obj.Add("UserName", userName);

                return obj;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

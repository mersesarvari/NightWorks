using Microsoft.IdentityModel.Tokens;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{

    public static class JWTToken
    {
        public static string CreateToken(User user)
        {
            List<Claim> lista = new List<Claim>();
            lista.Add(new Claim(ClaimTypes.Name, user.Username));            
            lista.Add(new Claim(ClaimTypes.Email, user.Email));
            lista.Add(new Claim(ClaimTypes.Authentication, user.Password));            
            lista.Add(new Claim(ClaimTypes.Role, user.Role.Name));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secure.Key));
            ;
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: lista,
                expires: DateTime.UtcNow.AddDays(5),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}

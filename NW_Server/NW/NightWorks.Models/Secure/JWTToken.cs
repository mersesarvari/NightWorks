using Microsoft.AspNetCore.Http;
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
            lista.Add(new Claim("id", user.Id.ToString()));
            lista.Add(new Claim("username", user.Username));            
            lista.Add(new Claim("email", user.Email));
            lista.Add(new Claim("password", user.Password));            
            lista.Add(new Claim("role", user.Role.Name));
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
        public static JwtSecurityToken DecodeToken(string stream) {
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(stream);

        }
        //Már nem jó mert át lettek nevezve a jwt token adatok
        public static string GetDataFromToken(HttpContext context, string type) {
            ClaimsIdentity identity = context.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            var data = claim.Where(x => x.Type == type).FirstOrDefault().ToString().Split(':')[1].Trim();
            return data;

        }
    }
}

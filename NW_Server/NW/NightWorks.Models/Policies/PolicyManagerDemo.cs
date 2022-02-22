using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public static class PolicyManager
    {
        //Basic policy for CRUD methods 
        public static bool BasicPolicy(HttpContext context, int ownerid, string Authorization)
        {
            int userid = int.Parse(JWTToken.GetDataFromToken(context, "_id").Trim());
            var role = JWTToken.GetDataFromToken(context, "_role").Trim();
            if (role == "admin" || role == "root" || role == "moderator" || ownerid == userid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

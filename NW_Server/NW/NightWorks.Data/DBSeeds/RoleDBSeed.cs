using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class RoleDBSeed
    {
        public RoleDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            Role role1 = new Role() { Name = "root", Permission = 100 };
            Role role2 = new Role() { Name = "admin", Permission = 90 };
            Role role3 = new Role() { Name = "moderator", Permission = 80 };
            Role role4 = new Role() { Name = "user", Permission = 20 };
            Role role5 = new Role() { Name = "guest", Permission = 10 };
            mb.Entity<Role>().HasData(role1, role2, role3, role4, role5);
        }
    }
}

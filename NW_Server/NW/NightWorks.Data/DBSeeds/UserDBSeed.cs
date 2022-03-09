using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class UserDBSeed
    {
        public UserDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            User admin = new User()
            {
                Id = 1,
                Username = "root",
                Email = "root@root.com",
                Password = Secure.Encrypt("root"),
                Rolename = "admin",
                Money = 500,
                Validated = false,
                ProfilePictureRoot = @"profile1.jpg"
            };
            User a = new User() { 
                Id = 2, Username = "test1", 
                Email = "test1@test.com", 
                Password = Secure.Encrypt("test"), 
                Rolename = "user", 
                Money = 500, 
                Validated = false,
                ProfilePictureRoot = @"profile1.jpg"
            };
            User b = new User() {
                Id = 3, Username = "test2",
                Email = "test2@test.com",
                Password = Secure.Encrypt("test"),
                Rolename = "user", 
                Money = 200,
                Validated = false,
                ProfilePictureRoot = @"profile1.jpg"
            };
            mb.Entity<User>().HasData(a, b, admin);
        }
        
    }
}

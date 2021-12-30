﻿using Microsoft.EntityFrameworkCore;
using NightWorks.Models;
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
            Role role1 = new Role() { Id = 1, Name = "root", Permission = 100 };
            Role role2 = new Role() { Id = 2, Name = "admin", Permission = 90 };
            Role role3 = new Role() { Id = 3, Name = "moderator", Permission = 80 };
            Role role4 = new Role() { Id = 4, Name = "user", Permission = 20 };
            Role role5 = new Role() { Id = 5, Name = "guest", Permission = 10 };

            User a = new User() { Id = 1, Username = "test1", Email = "test1@test.com", Password = Secure.Encrypt("test"), Roleid = role1.Id, Money = 500, Validated = false };
            User b = new User() { Id = 2, Username = "test2", Email = "test2@test.com", Password = Secure.Encrypt("test"), Roleid = role3.Id, Money = 200, Validated = false };



            var posts = new List<Post>()
            {
                new Post() { Id = 1, Data = "Loren Imsum1", Postuserid= a.Id},
                new Post() { Id = 2, Data = "Loren Imsum2", Postuserid=b.Id},
                new Post() { Id = 3, Data = "Loren Imsum3", Postuserid=a.Id},
                new Post() { Id = 4, Data = "Loren Imsum4", Postuserid=b.Id},
                new Post() { Id = 5, Data = "Loren Imsum5", Postuserid=a.Id}

            };


            mb.Entity<User>().HasData(a, b);
            mb.Entity<Role>().HasData(role1, role2, role3, role4, role5);
            mb.Entity<Post>().HasData(posts);
        }
        
    }
}
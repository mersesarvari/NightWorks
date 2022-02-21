﻿using Microsoft.EntityFrameworkCore;
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
                Username = "admin",
                Email = "admin@admin.com",
                Password = Secure.Encrypt("admin"),
                Roleid = 2,
                Money = 500,
                Validated = false,
                ProfilePictureRoot = @"test1.png"
            };
            User a = new User() { 
                Id = 2, Username = "test1", 
                Email = "test1@test.com", 
                Password = Secure.Encrypt("test"), 
                Roleid = 4, Money = 500, 
                Validated = false,
                ProfilePictureRoot = @"test1.png"
            };
            User b = new User() {
                Id = 3, Username = "test2",
                Email = "test2@test.com",
                Password = Secure.Encrypt("test"),
                Roleid = 4, Money = 200,
                Validated = false,
                ProfilePictureRoot = @"test2.jpg"
            };
            mb.Entity<User>().HasData(a, b, admin);
        }
        
    }
}
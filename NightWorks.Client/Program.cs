using System;
using System.Collections.Generic;
using System.Threading;
using NigthWorks.Models;

namespace NigthWorks.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:5000");
            Thread.Sleep(8000);

            var roles = restService.Get<Role>("role");
            var users = restService.Get<User>("user");
            var posts = restService.Get<Post>("post");

            User u = new User()
            {
                Username = "client",
                Email = "client@c.com",
                Password = "client",
                Money = 0,
                Validated = false,
                Roleid = 1
            };
            Post p = new Post()
            {
                Data = "fromclient",
                Postuserid = 1
            };
            restService.Post<User>(u, "User");
            restService.Post<Post>(p, "post");


        }
        

    }
}

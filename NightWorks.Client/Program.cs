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
            RestService restService = new RestService("http://localhost:51716");
            Thread.Sleep(8000);

            var roles = restService.Get<Role>("role");
            var users = restService.Get<User>("user");
            var posts = restService.Get<Post>("post");

            foreach (var i in users)
            {
                Console.WriteLine(i.ToString()); 
            }
            

        }
        

    }
}

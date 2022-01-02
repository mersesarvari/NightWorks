using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NightWorks.Data;
using NightWorks.Models;
using NightWorks.Repository;
using NigthWorks.Data;
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
            var events = restService.Get<Event>("event");
            var keyword = restService.Get<Keyword>("keyword");
            var address = restService.Get<Address>("address");

            User u = new User()
            {
                Username = "client",
                Email = "client@c.com",
                Password = "client",
                Money = 0,
                Validated = false,
                Roleid = 1
            };
            Event_KeywordConnect ekc1 = new Event_KeywordConnect()
            {
                EventId = 1,
                KeywordId = 1
            };
            








        }
        

    }
}

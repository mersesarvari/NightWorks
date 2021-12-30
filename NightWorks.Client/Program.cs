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
            /*
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
            */
            Console.WriteLine("Program Started:");
            NWDbContext o = new NWDbContext();
            Console.WriteLine("Connected");

            EventRepository e = new EventRepository(o);
            Event e1 = new Event()
            {
                EventName = "TimeTestEvent",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = DateTime.Now.AddSeconds(10),
                EventText = "[Event1] If everything is good, this event has a creation date!",
                AddressId = 1,
                OwnerId = 1,

            };
            e.Create(e1);
            Console.WriteLine($"[{e.Read(3).Id}] Name: {e.Read(3).EventName}");
            Console.WriteLine("Creation time: "+e.Read(3).Creationtime.ToString());
            
            Console.WriteLine("Destruction time: " + e.Read(3).Endingdate.ToString());
            Task.Delay(new TimeSpan(0, 0, 10)).ContinueWith(
                o => {
                    Console.WriteLine($"{e.Read(3).EventName} was deleted after 10 seconds");
                    e.Delete(3);                    
                });
            
            Console.ReadLine();
            



        }
        

    }
}

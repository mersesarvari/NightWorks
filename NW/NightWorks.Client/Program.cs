﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NightWorks.Client;
using NightWorks.Data;
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
            var events = restService.Get<NWEvent>("event");
            var keyword = restService.Get<Keyword>("keyword");
            var address = restService.Get<Address>("address");

            var image = restService.Get<Address>("EventMainImage");
            /*
            _File file = new _File()
            {
                Id = 1,
                Directory = @"Images\",
                Name = "testimage",
                Extension = ".jpg"
            };
            */

            
        }
    }
}
using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class Event_User_ConnectDBSeed
    {
        public Event_User_ConnectDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            List<Event_User_Connect> eucs = new List<Event_User_Connect>();
            Event_User_Connect euc1 = new Event_User_Connect() { Id = 1, EventId = 1, UserId = 1 };
            Event_User_Connect euc2 = new Event_User_Connect() { Id = 2, EventId = 1, UserId = 2 };
            Event_User_Connect euc3 = new Event_User_Connect() { Id = 3, EventId = 2, UserId = 1 };
            Event_User_Connect euc4 = new Event_User_Connect() { Id = 4, EventId = 2, UserId = 2 };
            eucs.Add(euc1);
            eucs.Add(euc2);
            eucs.Add(euc3);
            eucs.Add(euc4);
            mb.Entity<Event_User_Connect>().HasData(eucs);
        }
    }
}

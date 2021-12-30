using Microsoft.EntityFrameworkCore;
using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class EventDBSeed
    {
        public EventDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            List<Event> events = new List<Event>();
            List<Address> addresses= new List<Address> ();
            List<Keyword> types = new List<Keyword>();
            List<Event_AddressConnect> eacs = new List<Event_AddressConnect>();
            List<Event_KeywordConnect> etcs = new List<Event_KeywordConnect>();
            List<Event_UserConnect> eucs = new List<Event_UserConnect>();


            Event e1 = new Event()
            {
                Id = 1,
                EventName = "ProbaEvent1",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2021, 12, 15, 18, 00, 00),
                EventText = "[Event1] This is our test events text. This text will fill de body od our posts",
                OwnerId = 1,

            };
            Event e2 = new Event()
            {
                Id = 2,
                EventName = "ProbaEvent2",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2021, 12, 15, 18, 00, 00),
                EventText = "[Event2] This is our test events text. This text will fill de body od our posts",
                OwnerId = 1,

            };
            events.Add(e1);
            events.Add(e2);

            Address a1 = new Address() { Id = 1, City = "Budapest", Country = "Hungary", Street="budapest utca", BuildingNumber = 12, PostalCode = 1029 };
            Address a2 = new Address() { Id = 2, City = "Szeged", Country = "Hungary", Street = "szeged utca", BuildingNumber = 5, PostalCode = 1035 };
            Address a3 = new Address() { Id = 3, City = "Pécs", Country = "Hungary", Street = "pécs utca", BuildingNumber = 68, PostalCode = 1040 };
            addresses.Add(a1);
            addresses.Add(a2);
            addresses.Add(a3);

            Keyword et1 = new Keyword() { Id = 1, Name = "Dance" };
            Keyword et2 = new Keyword() { Id = 2, Name = "Party" };
            Keyword et3 = new Keyword() { Id = 3, Name = "Biking" };
            types.Add(et1);
            types.Add(et2);
            types.Add(et3); 

            Event_KeywordConnect etc1 = new Event_KeywordConnect() { Id = 1, EventId = 1, KeywordId = 2};
            Event_KeywordConnect etc2 = new Event_KeywordConnect() { Id = 2, EventId = 1, KeywordId = 1 };
            etcs.Add(etc1);
            etcs.Add(etc2);

            Event_UserConnect euc1 = new Event_UserConnect() { Id = 1, EventId = 1, UserId = 1 };
            Event_UserConnect euc2 = new Event_UserConnect() { Id = 2, EventId = 1, UserId = 2 };
            //Event_UserConnect euc3 = new Event_UserConnect() { Id = 3, EventId = 2, UserId = 1 };
            //Event_UserConnect euc4 = new Event_UserConnect() { Id = 4, EventId = 2, UserId = 2 };
            eucs.Add(euc1);
            eucs.Add(euc2);
            //eucs.Add(euc3);
            //eucs.Add(euc4);

            Event_AddressConnect eac1 = new Event_AddressConnect() { Id = 1, AddressId = 1, EventId = 1 };
            Event_AddressConnect eac2 = new Event_AddressConnect() { Id = 2, AddressId = 3, EventId = 1 };
            eacs.Add(eac1);
            eacs.Add(eac2);

            mb.Entity<Event>().HasData(events);
            mb.Entity<Address>().HasData(addresses);
            mb.Entity<Keyword>().HasData(types);
            mb.Entity<Event_KeywordConnect>().HasData(etcs);
            mb.Entity<Event_UserConnect>().HasData(eucs);
            mb.Entity<Event_AddressConnect>().HasData(eacs);

        }
        
        
        
    }
}

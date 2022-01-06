using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
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
            List<NWEvent> events = new List<NWEvent>();
            List<Address> addresses= new List<Address> ();
            List<Keyword> types = new List<Keyword>();
            List<Event_Keyword_Connect> etcs = new List<Event_Keyword_Connect>();
            List<Event_User_Connect> eucs = new List<Event_User_Connect>();


            NWEvent e1 = new NWEvent()
            {
                Id = 1,
                EventName = "ProbaEvent1",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2021, 12, 15, 18, 00, 00),
                EventText = "[Event1] This is our test events text. This text will fill de body od our posts",
                Address_Id = 1,
                Owner_Id = 1,
                //EventMainImageId=1

            };
            NWEvent e2 = new NWEvent()
            {
                Id = 2,
                EventName = "ProbaEvent2",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2022, 01, 03, 00, 00, 00),
                EventText = "[Event2] This is our test events text. This text will fill de body od our posts",
                Address_Id=2,
                Owner_Id = 1,
                //EventMainImageId = 1

            };
            NWEvent e3 = new NWEvent()
            {
                Id = 3,
                EventName = "ProbaEvent2",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2022, 12, 15, 18, 00, 00),
                EventText = "[Event3] This is our test events text. This text will fill de body od our posts",
                Address_Id = 2,
                Owner_Id = 2,
                //EventMainImageId = 1

            };
            events.Add(e1);
            events.Add(e2);
            events.Add(e3);

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

            Event_Keyword_Connect etc1 = new Event_Keyword_Connect() {Id=1, EventId = 1, KeywordId = 1};
            Event_Keyword_Connect etc2 = new Event_Keyword_Connect() {Id=2, EventId = 1, KeywordId = 2 };
            Event_Keyword_Connect etc3 = new Event_Keyword_Connect() { Id = 3, EventId = 2, KeywordId = 1 };
            Event_Keyword_Connect etc4 = new Event_Keyword_Connect() { Id = 4, EventId = 2, KeywordId = 2 };
            etcs.Add(etc1);
            etcs.Add(etc2);
            etcs.Add(etc3);
            etcs.Add(etc4);

            Event_User_Connect euc1 = new Event_User_Connect() { Id = 1, EventId = 1, UserId = 1 };
            Event_User_Connect euc2 = new Event_User_Connect() { Id = 2, EventId = 1, UserId = 2 };
            Event_User_Connect euc3 = new Event_User_Connect() { Id = 3, EventId = 2, UserId = 1 };
            Event_User_Connect euc4 = new Event_User_Connect() { Id = 4, EventId = 2, UserId = 2 };
            eucs.Add(euc1);
            eucs.Add(euc2);
            eucs.Add(euc3);
            eucs.Add(euc4);

            mb.Entity<NWEvent>().HasData(events);
            mb.Entity<Address>().HasData(addresses);
            mb.Entity<Keyword>().HasData(types);
            mb.Entity<Event_Keyword_Connect>().HasData(etcs);
            mb.Entity<Event_User_Connect>().HasData(eucs);

        }
        
        
        
    }
}

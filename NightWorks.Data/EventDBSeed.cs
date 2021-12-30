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
        public static List<Event> events = new List<Event>();
        public static List<Address> addresses = new List<Address>();
        public static List<Event_Type> eventtypes = new List<Event_Type>();
        public static List<Event_AddressConnect> eac = new List<Event_AddressConnect>();
        public static List<Event_TypeConnect> etc = new List<Event_TypeConnect>();
        public static List<Event_UserConnect> euc = new List<Event_UserConnect>();
        public EventDBSeed()
        {
            LoadData(events,addresses,eventtypes,eac,etc,euc);
        }
        public static void LoadData(
            List<Event> events,
            List<Address> addresses,
            List<Event_Type> types,
            List<Event_AddressConnect> eacs,
            List<Event_TypeConnect> etcs,
            List<Event_UserConnect> eucs
            )
        {
            
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
                Id = 1,
                EventName = "ProbaEvent2",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2021, 12, 15, 18, 00, 00),
                EventText = "[Event2] This is our test events text. This text will fill de body od our posts",
                OwnerId = 1,

            };
            events.Add(e1);
            events.Add(e2);

            Address a1 = new Address() { Id = 1, City = "Budapest", Country = "Hungary", BuildingNumber = 12, PostalCode = 1029 };
            Address a2 = new Address() { Id = 2, City = "Szeged", Country = "Hungary", BuildingNumber = 5, PostalCode = 1035 };
            Address a3 = new Address() { Id = 3, City = "Pécs", Country = "Hungary", BuildingNumber = 68, PostalCode = 1040 };
            addresses.Add(a1);
            addresses.Add(a2);
            addresses.Add(a3);

            Event_Type et1 = new Event_Type() { Id = 1, Name = "Dance" };
            Event_Type et2 = new Event_Type() { Id = 1, Name = "Party" };
            Event_Type et3 = new Event_Type() { Id = 1, Name = "Biking" };
            types.Add(et1);
            types.Add(et2);
            types.Add(et3); 

            Event_TypeConnect etc1 = new Event_TypeConnect() { Id = 1, EventId = 1, TypeId = 2};
            Event_TypeConnect etc2 = new Event_TypeConnect() { Id = 2, EventId = 1, TypeId = 1 };
            etcs.Add(etc1);
            etcs.Add(etc2);

            Event_UserConnect euc1 = new Event_UserConnect() { Id = 1, EventId = 1, UserId = 1 };
            Event_UserConnect euc2 = new Event_UserConnect() { Id = 2, EventId = 1, UserId = 2 };
            Event_UserConnect euc3 = new Event_UserConnect() { Id = 3, EventId = 2, UserId = 1 };
            Event_UserConnect euc4 = new Event_UserConnect() { Id = 4, EventId = 2, UserId = 2 };
            eucs.Add(euc1);
            eucs.Add(euc2);
            eucs.Add(euc3);
            eucs.Add(euc4);

            Event_AddressConnect eac1 = new Event_AddressConnect() { Id = 1, AddressId = 1, EventId = 1 };
            Event_AddressConnect eac2 = new Event_AddressConnect() { Id = 2, AddressId = 3, EventId = 1 };
            eacs.Add(eac1);
            eacs.Add(eac2);

        }
        
        
        
    }
}

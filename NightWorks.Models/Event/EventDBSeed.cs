using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public class EventDBSeed
    {
        public static List<Object> LoadData()
        {
            Address a1 = new Address() { Id = 1, City = "Budapest", Country = "Hungary", BuildingNumber = 12, PostalCode = 1029 };
            Address a2 = new Address() { Id = 2, City = "Szeged", Country = "Hungary", BuildingNumber = 5, PostalCode = 1035 };
            Address a3 = new Address() { Id = 3, City = "Pécs", Country = "Hungary", BuildingNumber = 68, PostalCode = 1040 };

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

            Event_Type et1 = new Event_Type() { Id = 1, Name = "Dance" };
            Event_Type et2 = new Event_Type() { Id = 1, Name = "Party" };
            Event_Type et3 = new Event_Type() { Id = 1, Name = "Biking" };

            Event_TypeConnect etc1 = new Event_TypeConnect() { Id = 1, EventId = 1, TypeId = 2 };
            Event_TypeConnect etc2 = new Event_TypeConnect() { Id = 2, EventId = 1, TypeId = 1 };

            Event_UserConnect euc1 = new Event_UserConnect() { Id = 1, EventId = 1, UserId = 1 };
            Event_UserConnect euc2 = new Event_UserConnect() { Id = 2, EventId = 1, UserId = 2 };
            Event_UserConnect euc3 = new Event_UserConnect() { Id = 3, EventId = 2, UserId = 1 };
            Event_UserConnect euc4 = new Event_UserConnect() { Id = 4, EventId = 2, UserId = 2 };

            Event_AddressConnect eac1 = new Event_AddressConnect() { Id = 1, AddressId = 1, EventId = 1 };
            Event_AddressConnect eac2 = new Event_AddressConnect() { Id = 2, AddressId = 3, EventId = 1 };

            //Addresses
            var alist = new List<Address>();
            alist.Add(a1);
            alist.Add(a2);
            alist.Add(a3);

            //Events
            var elist = new List<Event>();
            elist.Add(e1);
            elist.Add(e2);

            //EventTypes
            var etlist = new List<Event_Type>();
            etlist.Add(et1);
            etlist.Add(et2);

            //EventTypes
            var etclist = new List<Event_TypeConnect>();
            etclist.Add(etc1);
            etclist.Add(etc2);

            var euclist = new List<Event_UserConnect>();
            euclist.Add(euc1);
            euclist.Add(euc2);
            euclist.Add(euc3);
            euclist.Add(euc4);

            var eaclist = new List<Event_AddressConnect>();
            eaclist.Add(eac1);
            eaclist.Add(eac2);


            List<Object> list = new List<Object>();
            list.Add(alist);
            list.Add(elist);
            list.Add(etlist);
            list.Add(etclist);
            list.Add(euclist);
            list.Add(eaclist);

            return list;

        }
        
        
        
    }
}

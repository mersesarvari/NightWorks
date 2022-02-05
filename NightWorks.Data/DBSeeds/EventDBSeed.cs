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
            NWEvent e1 = new NWEvent()
            {
                Id = 1,
                EventName = "ProbaEvent1",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2021, 12, 15, 18, 00, 00),
                EventText = "[Event1] This is our test events text. This text will fill de body od our posts",
                Address_Id = 1,
                Owner_Id = 1

            };
            NWEvent e2 = new NWEvent()
            {
                Id = 2,
                EventName = "ProbaEvent2",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2022, 01, 03, 00, 00, 00),
                EventText = "[Event2] This is our test events text. This text will fill de body od our posts",
                Address_Id=2,
                Owner_Id = 1

            };
            NWEvent e3 = new NWEvent()
            {
                Id = 3,
                EventName = "ProbaEvent2",
                Startingdate = new DateTime(2021, 12, 15, 15, 30, 00),
                Endingdate = new DateTime(2022, 12, 15, 18, 00, 00),
                EventText = "[Event3] This is our test events text. This text will fill de body od our posts",
                Address_Id = 3,
                Owner_Id = 2

            };
            events.Add(e1);
            events.Add(e2);
            events.Add(e3);
            mb.Entity<NWEvent>().HasData(events);
        }
    }
}

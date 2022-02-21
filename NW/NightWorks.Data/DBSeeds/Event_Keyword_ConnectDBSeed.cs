﻿using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class Event_Keyword_ConnectDBSeed
    {
        public Event_Keyword_ConnectDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            List<Event_Keyword_Connect> etcs = new List<Event_Keyword_Connect>();
            Event_Keyword_Connect etc1 = new Event_Keyword_Connect() { Id = 1, FK_EventId = 1, FK_KeywordId = 1 };
            Event_Keyword_Connect etc2 = new Event_Keyword_Connect() { Id = 2, FK_EventId = 1, FK_KeywordId = 2 };
            etcs.Add(etc1);
            etcs.Add(etc2);
            mb.Entity<Event_Keyword_Connect>().HasData(etc1,etc2);
        }
    }
}
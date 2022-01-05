﻿using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IEvent_KeywordConnectRepository
    {
        public Event_Keyword_Connect Read(int id);
        public void Create(Event_Keyword_Connect obj);

        public void Update(Event_Keyword_Connect obj);

        public void Delete(int id);

        public List<Event_Keyword_Connect> ReadAll();

        public bool NotExisting(int id, int id2);

        public Event_Keyword_Connect ReadByData(int evenid, int keywordid);
    }
}

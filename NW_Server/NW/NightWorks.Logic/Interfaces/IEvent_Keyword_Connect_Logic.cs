﻿using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public interface IEvent_Keyword_Connect_Logic
    {
        public Event_Keyword_Connect Read(int id);
        public void Create(Event_Keyword_Connect obj);

        public void Update(Event_Keyword_Connect obj);

        public void Delete(int id);

        public IList<Event_Keyword_Connect> ReadAll();
    }
}

using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public interface IEvent_KeywordConnectLogic
    {
        public Event_KeywordConnect Read(int id);
        public void Create(Event_KeywordConnect obj);

        public void Update(Event_KeywordConnect obj);

        public void Delete(int id);

        public List<Event_KeywordConnect> ReadAll();
    }
}

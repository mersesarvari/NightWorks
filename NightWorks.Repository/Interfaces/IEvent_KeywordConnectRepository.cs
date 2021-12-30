using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IEvent_KeywordConnectRepository
    {
        public Event_KeywordConnect Read(int id);
        public void Create(Event_KeywordConnect obj);

        public void Update(Event_KeywordConnect obj);

        public void Delete(int id);

        public List<Event_KeywordConnect> ReadAll();

        public bool NotExisting(int id, int id2);

        public Event_KeywordConnect ReadByData(int evenid, int keywordid);
    }
}

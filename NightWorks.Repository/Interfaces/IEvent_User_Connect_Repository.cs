using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IEvent_User_Connect_Repository
    {
        public Event_User_Connect Read(int id);
        public void Create(Event_User_Connect obj);

        public void Update(Event_User_Connect obj);

        public void Delete(int id);

        public List<Event_User_Connect> ReadAll();

        public bool NotExisting(int id, int id2);

        public Event_User_Connect ReadByData(int evenid, int userid);
    }
}

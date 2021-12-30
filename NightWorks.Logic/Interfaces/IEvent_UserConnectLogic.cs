using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public interface IEvent_UserConnectLogic
    {
        public Event_UserConnect Read(int id);
        public void Create(Event_UserConnect obj);

        public void Update(Event_UserConnect obj);

        public void Delete(int id);

        public List<Event_UserConnect> ReadAll();
    }
}

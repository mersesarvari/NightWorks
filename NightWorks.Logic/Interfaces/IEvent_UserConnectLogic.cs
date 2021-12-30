using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IEvent_UserConnectRepository
    {
        public Event_UserConnect Read(int id);
        public void Create(Event_UserConnect obj);

        public void Update(Event_UserConnect obj);

        public void Delete(int id);

        public List<Event_UserConnect> ReadAll();
    }
}

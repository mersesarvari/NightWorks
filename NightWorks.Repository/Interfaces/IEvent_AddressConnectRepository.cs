using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IEvent_AddressConnectRepository
    {
        public Event_AddressConnect Read(int id);
        public void Create(Event_AddressConnect obj);

        public void Update(Event_AddressConnect obj);

        public void Delete(int id);

        public List<Event_AddressConnect> ReadAll();
    }
}

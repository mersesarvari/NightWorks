using NightWorks.Models;
using NigthWorks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class Event_AddressConnectRepository : IEvent_AddressConnectRepository
    {
        NWDbContext db;
        public Event_AddressConnectRepository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(Event_AddressConnect obj)
        {
            db.Event_AddressConnects.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Event_AddressConnect Read(int id)
        {
            return db.Event_AddressConnects.FirstOrDefault(o => o.Id == id);
        }

        public List<Event_AddressConnect> ReadAll()
        {
            return db.Event_AddressConnects.ToList();
        }

        public void Update(Event_AddressConnect obj)
        {
            var old = Read(obj.Id);
            old.AddressId = obj.AddressId;
            old.EventId = obj.EventId;
            db.SaveChanges();
        }
    }
}

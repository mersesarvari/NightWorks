using NightWorks.Models;
using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class EventRepository:IEventRepository 
    {
        NWDbContext db;
        public EventRepository(NWDbContext db)
        {
            this.db = db;
        }

        public void Create(Event item)
        {
            var context = new NWDbContext();
            context.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = Read(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Event not found"
                );
            }
            db.Remove(x);
            db.SaveChanges();
        }

        public List<Address> GetEventAddresses(int id)
        {
            Event x = Read(id);
            List<Address> addresses = new List<Address>();
            foreach (var item in x.EAddressConns)
            {
                addresses.Add(item.EventAddress);
            }
            return addresses;
        }

        public List<Keyword> GetEventTypes(int id)
        {
            Event x = Read(id);
            List<Keyword> types = new List<Keyword>();
            foreach (var item in x.EKeywordConns)
            {
                types.Add(item.Keyword);
            }
            return types;
        }

        public List<User> GetEventUsers(int id)
        {
            Event x = Read(id);
            List<User> u = new List<User>();
            foreach (var item in x.EUserConns)
            {
                u.Add(item.User);
            }
            return u;
        }

        public Event Read(int id)
        {
            return db.Events.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Event> ReadAll()
        {
            return db.Events;
        }

        public void Update(Event item)
        {
            var s = Read(item.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Event not found"
                );
            }
            s.EventName = item.EventName;
            s.OwnerId = item.OwnerId;
            s.Startingdate = item.Startingdate;
            s.Endingdate = item.Endingdate;
            s.EventText = item.EventText;
            db.SaveChanges();
        }
    }
}

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

        public void Create(NWEvent item)
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
            throw new NotImplementedException();
        }

        public List<Keyword> GetEventTypes(int id)
        {
            NWEvent x = Read(id);
            List<Keyword> types = new List<Keyword>();
            foreach (var item in x.EKeywordConns)
            {
                types.Add(item.Keyword);
            }
            return types;
        }

        public List<User> GetEventUsers(int id)
        {
            NWEvent x = Read(id);
            List<User> u = new List<User>();
            foreach (var item in x.EUserConns)
            {
                u.Add(item.User);
            }
            return u;
        }

        public NWEvent Read(int id)
        {
            return db.Events.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<NWEvent> ReadAll()
        {
            return db.Events;
        }        

        public void Update(NWEvent item)
        {
            var s = Read(item.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Event not found"
                );
            }
            s.Address_Id = item.Address_Id;
            s.EventName = item.EventName;
            s.Owner_Id = item.Owner_Id;
            s.Startingdate = item.Startingdate;
            s.Endingdate = item.Endingdate;
            s.EventText = item.EventText;
            db.SaveChanges();
        }
    }
}

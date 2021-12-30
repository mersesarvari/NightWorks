using NightWorks.Models;
using NigthWorks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class Event_UserConnectRepository:IEvent_UserConnectRepository
    {
        NWDbContext db;
        public Event_UserConnectRepository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(Event_UserConnect obj)
        {
            if (NotExisting(obj.EventId, obj.UserId))
            {
                db.Event_UserConnects.Add(obj);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Cannot make this modify. This relation already defined!");
            }
        }

        public void Delete(int id)
        {
            if (Read(id) !=null)
            {
                db.Remove(Read(id));
                db.SaveChanges();
            }
            else
            {
                throw new Exception("You cant delete this item, because it is not existing!");
            }
            
        }

        public Event_UserConnect Read(int id)
        {
            return db.Event_UserConnects.FirstOrDefault(o => o.Id == id);
        }

        public List<Event_UserConnect> ReadAll()
        {
            return db.Event_UserConnects.ToList();
        }

        public void Update(Event_UserConnect obj)
        {
            if (NotExisting(obj.EventId, obj.UserId))
            {
                var old = Read(obj.Id);
                old.UserId = obj.UserId;
                old.EventId = obj.EventId;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Cannot make this modify. This relation already defined!");
            }
            
        }
        public bool NotExisting(int eventid, int userid)
        {
            bool existing = true;
            var list = ReadAll();
            foreach (var item in list)
            {
                if (item.EventId == eventid && item.UserId == userid)
                {
                    existing = false;
                }
            }
            return existing;
        }
    }
}

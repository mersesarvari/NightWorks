using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class Event_User_Connect_Repository:IEvent_User_ConnectRepository
    {
        NWDbContext db;
        public Event_User_Connect_Repository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(Event_User_Connect obj)
        {
            if (NotExisting(obj.EventId, obj.UserId))
            {
                db.Event_User_Connects.Add(obj);
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

        public Event_User_Connect Read(int id)
        {
            return db.Event_User_Connects.FirstOrDefault(o => o.Id == id);
        }

        public List<Event_User_Connect> ReadAll()
        {
            return db.Event_User_Connects.ToList();
        }

        public void Update(Event_User_Connect obj)
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

        public Event_User_Connect ReadByData(int eventid, int userid)
        {
            Event_User_Connect a = new Event_User_Connect();
            var list = ReadAll();
            foreach (var item in list)
            {
                if (item.EventId == eventid && item.UserId == userid)
                {
                    a.Id = item.Id;
                    a.EventId = item.EventId;
                    a.UserId = userid;
                }
            }
            if (a != null)
            {
                return a;
            }
            else
            {
                throw new Exception("This item doestn exist!");
            }
        }
    }
}

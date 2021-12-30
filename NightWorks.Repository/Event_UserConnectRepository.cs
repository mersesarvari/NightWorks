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
            db.Event_UserConnects.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
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
            var old = Read(obj.Id);
            old.UserId = obj.UserId;
            old.EventId = obj.EventId;
            db.SaveChanges();
        }
    }
}

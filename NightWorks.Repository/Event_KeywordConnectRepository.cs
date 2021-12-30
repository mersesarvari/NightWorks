using NightWorks.Models;
using NigthWorks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class Event_KeywordConnectRepository : IEvent_KeywordConnectRepository
    {
        NWDbContext db;
        public Event_KeywordConnectRepository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(Event_KeywordConnect obj)
        {
            db.Event_KeywordConnects.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Event_KeywordConnect Read(int id)
        {
            return db.Event_KeywordConnects.FirstOrDefault(o => o.Id == id);
        }

        public List<Event_KeywordConnect> ReadAll()
        {
            return db.Event_KeywordConnects.ToList();
        }

        public void Update(Event_KeywordConnect obj)
        {
            var old = Read(obj.Id);
            old.KeywordId = obj.KeywordId;
            old.EventId = obj.EventId;
            db.SaveChanges();
        }
    }
}

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
    public class KeywordRepository : IKeywordRepository
    {
        NWDbContext db;
        public KeywordRepository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(Keyword item)
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
                    "EventType with that id not found"
                );
            }
            db.Remove(x);
            db.SaveChanges();
        }

        public List<Event> GetTypeEvents(int id)
        {
            Keyword x = Read(id);
            List<Event> list = new List<Event>();
            foreach (var item in x.EKeywordConns)
            {
                list.Add(item.Event);
            }
            return list;
        }

        public Keyword Read(int id)
        {
            return db.Types.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Keyword> ReadAll()
        {
            return db.Types;
        }

        public void Update(Keyword item)
        {
            var s = Read(item.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Event not found"
                );
            }
            s.Name = item.Name;
            
            db.SaveChanges();
        }
    }
}

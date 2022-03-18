using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class Keyword_Repository : IKeyword_Repository
    {
        NWDbContext db;
        public Keyword_Repository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(Keyword item)
        {
            db.Add(item);
            db.SaveChanges();
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

        public IList<NWEvent> GetTypeEvents(int id)
        {
            Keyword x = Read(id);
            List<NWEvent> list = new List<NWEvent>();
            foreach (var item in x.Event_Keyword_Conns)
            {
                list.Add(item.Event);
            }
            return list;
        }

        public Keyword Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Keywords.FirstOrDefault(t => t.Id == id);
            }
        }

        public IList<Keyword> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Keywords.ToList();
            }
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
        public Keyword ReadByParameter(string name)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Keywords.FirstOrDefault(t => t.Name == name);
            }
        }
    }
}

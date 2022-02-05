using NightWorks.Logic;
using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorksLogic
{
    public class Keyword_Logic : IKeyword_Logic
    {
        NWDbContext db;
        public Keyword_Logic(NWDbContext db)
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
                    "Keyword with that id not found"
                );
            }
            db.Remove(x);
            db.SaveChanges();
        }

        public List<NWEvent> GetTypeEvents(int id)
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
            return db.Keywords.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Keyword> ReadAll()
        {
            return db.Keywords;
        }

        public void Update(Keyword item)
        {
            var s = Read(item.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Keyword not found"
                );
            }
            s.Name = item.Name;
            
            db.SaveChanges();
        }
    }
}

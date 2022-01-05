
using NigthWorks.Data;
using NigthWorks.Models;
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
        public void Create(Event_Keyword_Connect obj)
        {
            if (NotExisting(obj.EventId, obj.KeywordId))
            {
                db.Event_Keyword_Connects.Add(obj);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This relation is already defined!");
            }
            
        }
        public void Delete(int id)
        {
            if (Read(id)!=null)
            {
                db.Remove(Read(id));
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This item doesnt exist!");
            }
            
        }

        public Event_Keyword_Connect Read(int id)
        {
            return db.Event_Keyword_Connects.FirstOrDefault(o => o.Id == id);
        }

        public List<Event_Keyword_Connect> ReadAll()
        {
            return db.Event_Keyword_Connects.ToList();
        }

        public void Update(Event_Keyword_Connect obj)
        {
            if (NotExisting(obj.EventId, obj.KeywordId))
            {
                var old = Read(obj.Id);
                old.KeywordId = obj.KeywordId;
                old.EventId = obj.EventId;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Cannot make this modify. This relation already defined!");
            }
            
        }
        public bool NotExisting(int eventid, int keywordid)
        {
            bool existing=true;
            var list = ReadAll();
            foreach (var item in list)
            {
                if (item.EventId == eventid && item.KeywordId == keywordid)
                {
                    existing = false;
                }
            }
            return existing;
        }

        public Event_Keyword_Connect ReadByData(int eventid, int keywordid)
        {
            Event_Keyword_Connect a=new Event_Keyword_Connect();
            var list = ReadAll();
            foreach (var item in list)
            {
                if (item.EventId == eventid && item.KeywordId == keywordid)
                {
                    a.Id=item.Id;
                    a.EventId = item.EventId;
                    a.KeywordId=keywordid;
                }
            }
            if (a!=null)
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

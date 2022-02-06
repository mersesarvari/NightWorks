
using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class Event_Keyword_ConnectRepository : IEvent_Keyword_ConnectRepository
    {
        NWDbContext db;
        public Event_Keyword_ConnectRepository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(Event_Keyword_Connect obj)
        {
            if (NotExisting(obj.FK_EventId, obj.FK_KeywordId))
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
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Event_Keyword_Connects.FirstOrDefault(t => t.Id == id);
            }
        }

        public IList<Event_Keyword_Connect> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Event_Keyword_Connects.ToList();
            }
        }

        public void Update(Event_Keyword_Connect obj)
        {
            if (NotExisting(obj.FK_EventId, obj.FK_KeywordId))
            {
                var old = Read(obj.Id);
                old.FK_KeywordId = obj.FK_KeywordId;
                old.FK_EventId = obj.FK_EventId;
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
                if (item.FK_EventId == eventid && item.FK_KeywordId == keywordid)
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
                if (item.FK_EventId == eventid && item.FK_KeywordId == keywordid)
                {
                    a.Id=item.Id;
                    a.FK_EventId = item.FK_EventId;
                    a.FK_KeywordId=keywordid;
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

using NightWorks.Models;
using NigthWorks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class SaveEventToUser_Repository : ISaveEventToUser_Repository
    {
        NWDbContext db;
        public SaveEventToUser_Repository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(SaveEventToUser obj)
        {
            if (NotExisting(obj.UserId, obj.EventId))
            {
                db.SaveEventToUser_Connect.Add(obj);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This relation is already defined!");
            }
        }
        public void Delete(int id)
        {
            if (Read(id) != null)
            {
                db.Remove(Read(id));
                db.SaveChanges();
            }
            else
            {
                throw new Exception("This item doesnt exist!");
            }

        }
        public SaveEventToUser Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.SaveEventToUser_Connect.FirstOrDefault(t => t.Id == id);
            }
        }
        public IList<SaveEventToUser> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.SaveEventToUser_Connect.ToList();
            }
        }
        public void Update(SaveEventToUser obj)
        {
            if (NotExisting(obj.UserId, obj.EventId))
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
        public bool NotExisting(int userid, int eventid)
        {
            bool existing = true;
            var list = ReadAll();
            foreach (var item in list)
            {
                if (item.UserId == userid && item.EventId == eventid)
                {
                    existing = false;
                }
            }
            return existing;
        }
        public SaveEventToUser ReadByData(int userid, int eventid)
        {
            SaveEventToUser a = new SaveEventToUser();
            var list = ReadAll();
            foreach (var item in list)
            {
                if (item.UserId == userid && item.EventId == eventid)
                {
                    a.Id = item.Id;
                    a.UserId = item.UserId;
                    a.EventId = item.EventId;
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

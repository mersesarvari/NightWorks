
using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class UserSettings_Keyword_ConnectRepository : IUserSettings_Keyword_ConnectRepository
    {
        NWDbContext db;
        public UserSettings_Keyword_ConnectRepository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(UserSettings_Keyword_Connect obj)
        {
            if (NotExisting(obj.FK_UserSettingsId, obj.FK_KeywordId))
            {
                db.UserSettings_Keyword_Connects.Add(obj);
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

        public UserSettings_Keyword_Connect Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.UserSettings_Keyword_Connects.FirstOrDefault(t => t.Id == id);
            }
        }

        public IList<UserSettings_Keyword_Connect> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.UserSettings_Keyword_Connects.ToList();
            }
        }

        public void Update(UserSettings_Keyword_Connect obj)
        {
            if (NotExisting(obj.FK_UserSettingsId, obj.FK_KeywordId))
            {
                var old = Read(obj.Id);
                old.FK_KeywordId = obj.FK_KeywordId;
                old.FK_UserSettingsId = obj.FK_UserSettingsId;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Cannot make this modify. This relation already defined!");
            }
            
        }
        public bool NotExisting(int usersettingsid, int keywordid)
        {
            bool existing=true;
            var list = ReadAll();
            foreach (var item in list)
            {
                if (item.FK_UserSettingsId == usersettingsid && item.FK_KeywordId == keywordid)
                {
                    existing = false;
                }
            }
            return existing;
        }

        public UserSettings_Keyword_Connect ReadByData(int eventid, int keywordid)
        {
            UserSettings_Keyword_Connect a= new UserSettings_Keyword_Connect();
            var list = ReadAll();
            foreach (var item in list)
            {
                if (item.FK_UserSettingsId == eventid && item.FK_KeywordId == keywordid)
                {
                    a.Id=item.Id;
                    a.FK_UserSettingsId = item.FK_UserSettingsId;
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

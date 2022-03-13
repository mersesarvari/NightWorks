using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Repository
{
    public class User_Repository : IUser_Repository
    {

        NWDbContext db;
        public User_Repository(NWDbContext db)
        {
            this.db = db;  
        }

        public User Read(int id)
        {
            if (db==null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Users.FirstOrDefault(t => t.Id == id);
            }            
        }

        public void Create(User obj)
        {
            db.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = Read(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "User not found"
                );
            }
            db.Remove(x);
            db.SaveChanges();
        }

        public void Update(User obj)
        {
            User temp = Read(obj.Id);
            if (temp == null)
            {
                throw new InvalidOperationException(
                    "User not found"
                );
            }
            temp.Username = obj.Username;
            db.SaveChanges();
        }

        public IList<User> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Users.ToList();
            }
        }

        public User GetUserbyEmail(string email)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                if (db.Users.FirstOrDefault(t => t.Email == email) != null)
                {
                    return db.Users.FirstOrDefault(t => t.Email == email);
                }
                else
                {
                    throw new Exception("Email address doesnt exists!");
                }
            }
            
        }

        public void SaveEvent(int userid, int eventid)
        {
            /*
            NWEvent tempevent;
            User tempuser = Read(userid);
            User change= new();
            if (db != null)
            {
                tempevent = (db.Events.FirstOrDefault(x => x.Id == eventid));
            }
            else
            {
                throw new Exception("There is no data in database");
            }
            if (change.SavedEvents == null)
            {
                change.SavedEvents = new List<NWEvent>();
            }
            change.SavedEvents.Add(tempevent);
            tempuser.SavedEvents = change.SavedEvents;            
            db.SaveChanges();
            */
        }
    }
}

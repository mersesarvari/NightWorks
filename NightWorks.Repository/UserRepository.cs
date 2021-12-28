using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;
using NightWorks.Models;

namespace NigthWorks.Repository
{
    public class UserRepository : IUserRepository
    {

        XYZDbContext db;
        public UserRepository(XYZDbContext db)
        {
            this.db = db;  
        }

        public User Read(int id)
        {
            return db.Users.FirstOrDefault(t => t.Id == id);
        }

        public void Create(User obj)
        {
            var context = new XYZDbContext();
            context.Add(obj);
            context.SaveChanges();
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
            var s = Read(obj.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "User not found"
                );
            }
            s.Money = obj.Money;
            s.Username = obj.Username;
            db.SaveChanges();
        }

        public IQueryable<User> ReadAll()
        {
            return db.Users;
        }

        public User GetUserbyEmail(string email)
        {
            if (db.Users.FirstOrDefault(t => t.Email == email) != null)
            {
                return db.Users.FirstOrDefault(t => t.Email == email)
            }
            else
            {
                throw new Exception("Email address doesnt exists!");
            }
        }

    }
}

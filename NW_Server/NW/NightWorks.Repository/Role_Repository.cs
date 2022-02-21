using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Models;
using NigthWorks.Data;

namespace NigthWorks.Repository
{
    //Crud: Create, Read, ReadAll, Update, Delete
    public class Role_Repository : IRole_Repository
    {
        NWDbContext db;
        public Role_Repository(NWDbContext db)
        {
            this.db = db;
        }

        public Role Read(string role)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Roles.FirstOrDefault(t => t.Name == role);
            }
        }
        public void Create(Role obj)
        {
            db.Roles.Add(obj);
            db.SaveChanges();
        }

        public void Delete(string role)
        {
            db.Remove(Read(role));
            db.SaveChanges();
        }

        public void Update(Role obj)
        {
            
            var oldbrand = Read(obj.Name);
            oldbrand.Name = obj.Name;
            db.SaveChanges();
        }

        public IList<Role> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Roles.ToList();
            }
        }
    }
}

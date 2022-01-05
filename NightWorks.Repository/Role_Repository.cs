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
    public class Role_Repository : IRoleRepository
    {
        NWDbContext db;
        public Role_Repository(NWDbContext db)
        {
            this.db = db;
        }

        public Role Read(int id)
        {
            return db.Roles.FirstOrDefault(t => t.Id == id);
        }
        public void Create(Role obj)
        {
            db.Roles.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Role obj)
        {
            
            var oldbrand = Read(obj.Id);
            oldbrand.Name = obj.Name;
            db.SaveChanges();
        }

        public IQueryable<Role> ReadAll()
        {
            return db.Roles;
        }
    }
}

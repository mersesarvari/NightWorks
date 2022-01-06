using NigthWorks.Data;
using NigthWorks.Models;
using NigthWorks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class EventMainImage_Repository : IFilemanager_Repository
    {
        NWDbContext db;
        public void Create(_File item)
        {
            db.EventMainImages.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.EventMainImages.Remove(Read(id));
            db.SaveChanges();
        }

        public _File Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.EventMainImages.FirstOrDefault(t => t.Id == id);
            }
        }

        public IQueryable<_File> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in that table");
            }
            else
            {
                return db.EventMainImages;
            }
            
        }

        public void Update(_File item)
        {
            var oldbrand = Read(item.Id);
            db.SaveChanges();
        }
    }
}

using NigthWorks.Data;
using NigthWorks.Models;
using NigthWorks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NightWorks.Repository
{
    public class File_Repository : IFile_Repository
    {
        NWDbContext db;
        public void Create(_File item)
        {
            db.Files.Add(item);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Files.Remove(Read(id));
            db.SaveChanges();
        }
        public void DeleteByPath(string path)
        {
            db.Files.Remove(ReadByPath(path));
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
                return db.Files.FirstOrDefault(t => t.Id == id);
            }
        }
        public _File ReadByPath(string path)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Files.FirstOrDefault(t => t.FilePath == path);
            }
        }
        public IList<_File> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in that table");
            }
            else
            {
                return db.Files.ToList();
            }
            
        }
        public void Update(_File obj)
        {
            var oldbrand = Read(obj.Id);
            db.SaveChanges();
        }
    }
}

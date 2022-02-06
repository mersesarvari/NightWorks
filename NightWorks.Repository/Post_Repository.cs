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
    public class Post_Repository : IPost_Repository
    {
        NWDbContext db;
        public Post_Repository(NWDbContext db)
        {
            this.db = db;
        }

        public Post Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Posts.FirstOrDefault(t => t.Id == id);
            }
        }
        public void Create(Post obj)
        {
            db.Posts.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Post obj)
        {
            var oldbrand = Read(obj.Id);
            oldbrand.Data = obj.Data;
            db.SaveChanges();
        }

        public IList<Post> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Posts.ToList();
            }
        }


    }
}

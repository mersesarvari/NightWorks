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
    public class PostRepository : IPostRepository
    {
        XYZDbContext db;
        public PostRepository(XYZDbContext db)
        {
            this.db = db;
        }

        public Post Read(int id)
        {
            return db.Posts.FirstOrDefault(t => t.Id == id);
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
            oldbrand.Text = obj.Text;
            db.SaveChanges();
        }

        public IQueryable<Post> ReadAll()
        {
            return db.Posts;
        }


    }
}

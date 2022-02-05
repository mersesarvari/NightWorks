using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class PostDBSeed
    {
        public PostDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            var posts = new List<Post>()
            {
                new Post() { Id = 1, Data = "Loren Imsum1", Post_UserId= 1},
                new Post() { Id = 2, Data = "Loren Imsum2", Post_UserId=2},
                new Post() { Id = 3, Data = "Loren Imsum3", Post_UserId=1},
                new Post() { Id = 4, Data = "Loren Imsum4", Post_UserId=1},
                new Post() { Id = 5, Data = "Loren Imsum5", Post_UserId=1}

            };
            mb.Entity<Post>().HasData(posts);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class KeywordDBSeed
    {
        public KeywordDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            List<Keyword> types = new List<Keyword>();
            Keyword et1 = new Keyword() { Id = 1, Name = "Dance" };
            Keyword et2 = new Keyword() { Id = 2, Name = "Party" };
            Keyword et3 = new Keyword() { Id = 3, Name = "Biking" };
            types.Add(et1);
            types.Add(et2);
            types.Add(et3);
            mb.Entity<Keyword>().HasData(types);
        }
    }
}

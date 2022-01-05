using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data.DBSeeds
{
    public class ImageDBSeed
    {
        public ImageDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            ImageHandler image1 = new ImageHandler()
            {
                
            };
        }

    }
}

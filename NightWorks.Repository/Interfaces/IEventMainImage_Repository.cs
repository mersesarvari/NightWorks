using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Repository
{
    public interface IEventMainImage_Repository
    {
        void Create(ImageHandler item);
        void Delete(int id);
        ImageHandler Read(int id);
        IQueryable<ImageHandler> ReadAll();
        void Update(ImageHandler item);
    }
}

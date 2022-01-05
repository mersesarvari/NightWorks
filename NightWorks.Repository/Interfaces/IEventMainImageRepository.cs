using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Repository
{
    public interface IEventMainImageRepository
    {
        void Create(EventMainImage item);
        void Delete(int id);
        EventMainImage Read(int id);
        IQueryable<EventMainImage> ReadAll();
        void Update(EventMainImage item);
    }
}

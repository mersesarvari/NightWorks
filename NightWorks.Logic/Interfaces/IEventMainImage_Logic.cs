
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NigthWorks.Logic
{
    public interface IEventMainImage_Logic
    {
        EventMainImage Read(int id);
        IEnumerable<EventMainImage> ReadAll();
        void Create(EventMainImage obj);
        void Update(EventMainImage obj);
        void Delete(int id);
    }
}

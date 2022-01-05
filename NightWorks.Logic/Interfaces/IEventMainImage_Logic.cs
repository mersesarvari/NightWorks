
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
        ImageHandler Read(int id);
        IEnumerable<ImageHandler> ReadAll();
        void Create(ImageHandler obj);
        void Update(ImageHandler obj);
        void Delete(int id);
    }
}

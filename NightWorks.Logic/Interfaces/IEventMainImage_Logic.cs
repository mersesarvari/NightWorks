
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
        _File Read(int id);
        IEnumerable<_File> ReadAll();
        void Create(_File obj);
        void Update(_File obj);
        void Delete(int id);
    }
}

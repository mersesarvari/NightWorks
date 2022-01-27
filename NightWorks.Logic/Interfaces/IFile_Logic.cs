using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Models;

namespace NigthWorks.Logic
{
    public interface IFile_Logic
    {
        _File Read(int id);
        _File ReadByPath(int id);
        IEnumerable<_File> ReadAll();
        void Create(_File obj);
        void Update(_File obj);
        void Delete(int id);

        void DeleteByPath(string path);
    }
}

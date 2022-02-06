using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Repository
{
    public interface IFile_Repository
    {
        void Create(_File item);
        void Delete(int id);
        _File Read(int id);
        _File ReadByPath(string path);
        void DeleteByPath(string path);
        IList<_File> ReadAll();
        void Update(_File item);
    }
}

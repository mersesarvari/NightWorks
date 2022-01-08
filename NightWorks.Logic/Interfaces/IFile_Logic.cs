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
        FileStream Read(string path);
        IEnumerable<FileStream> ReadAll();
        void Create(FileStream obj);
        void Update(FileStream obj);
        void Delete(string path);
    }
}

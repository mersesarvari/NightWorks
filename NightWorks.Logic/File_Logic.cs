using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Models;
using NigthWorks.Repository;

namespace NigthWorks.Logic
{
    public class File_Logic : IFile_Logic
    {
        IFile_Repository repo;

        public File_Logic(IFile_Repository repo)
        {
            this.repo = repo;
        }

        public void Create(FileStream obj)
        {
            repo.Create(
                new _File()
                {
                    
                }
            );
        }

        public void Delete(string path)
        {
            File.Delete(path);
            repo.Delete(path);
        }

        public FileStream Read(string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileStream> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(FileStream obj)
        {
            throw new NotImplementedException();
        }
    }
}

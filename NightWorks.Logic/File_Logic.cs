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

        public void Create(_File obj)
        {
            repo.Create(obj);
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public void DeleteByPath(string path)
        {
            repo.DeleteByPath(path);
        }

        public _File Read(int id)
        {
            return repo.Read(id);
        }
        public IList<_File> ReadAll()
        {
            return repo.ReadAll();
        }

        public _File ReadByPath(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(_File obj)
        {
            throw new NotImplementedException();
        }
    }
}

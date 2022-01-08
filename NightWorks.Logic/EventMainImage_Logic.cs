using NigthWorks.Logic;
using NigthWorks.Models;
using NigthWorks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public class EventMainImage_Logic : IEventMainImage_Logic
    {
        IFile_Repository repo;

        public EventMainImage_Logic(IFile_Repository repo)
        {
            this.repo = repo;
        }

        public void Create(_File obj)
        {
            repo.Create(obj);
        }

        public void Delete(int id)
        {
            if (repo.Read(id) != null)
            {
                repo.Delete(id);
            }
            else
            {
                throw new Exception("There is no Starship with thad id");
            }
        }

        public _File Read(int id)
        {
            return repo.Read(id);
        }

        public IEnumerable<_File> ReadAll()
        {
            if (repo.ReadAll()==null)
            {
                throw new Exception("cant load data because there is no data");
            }
            else
            {
                return repo.ReadAll();
            }
            
        }

        public void Update(_File obj)
        {

                repo.Update(obj);

        }
    }
}

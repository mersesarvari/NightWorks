using NightWorks.Logic;
using NightWorks.Repository;
using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorksLogic
{
    public class Keyword_Logic : IKeyword_Logic
    {
        IKeyword_Repository repo;
        public Keyword_Logic(IKeyword_Repository repo)
        {
            this.repo = repo;
        }
        public void Create(Keyword item)
        {
            if (repo.ReadByParameter(item.Name) == null)
            {
                repo.Create(item);
            }
            else
            {
                throw new Exception("This keyword is already exists");
            }
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IList<NWEvent> GetTypeEvents(int id)
        {
            return repo.GetTypeEvents(id);
        }

        public Keyword Read(int id)
        {
            return repo.Read(id);
        }

        public IList<Keyword> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Keyword item)
        {
            repo.Update(item);
        }
    }
}

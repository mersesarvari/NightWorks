using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public class EventMainImage_Logic : IEventMainImage_Logic
    {
        IEventMainImage_Logic repo;

        public EventMainImage_Logic(IEventMainImage_Logic repo)
        {
            this.repo = repo;
        }

        public void Create(EventMainImage obj)
        {
            if (obj.Title == "" || obj.Data == null)
            {
                throw new Exception("Not all data have been verified. Something is missing");
            }
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

        public EventMainImage Read(int id)
        {
            return repo.Read(id);
        }

        public IEnumerable<EventMainImage> ReadAll()
        {
            return repo.ReadAll().ToList();
        }

        public void Update(EventMainImage obj)
        {
            if (obj.Title == "" || obj.Data == null)
            {
                repo.Update(obj);
            }
            else
            {
                throw new Exception("Some Data is not valid");
            }
        }
    }
}

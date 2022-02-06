using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Models;
using NigthWorks.Repository;

namespace NigthWorks.Logic
{
    public class Role_Logic : IRole_Logic
    {
        IRole_Repository brandRepository;

        public Role_Logic(IRole_Repository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public IList<Role> ReadAll()
        {
            return brandRepository.ReadAll().ToList();
        }

        public Role Read(int id)
        {
            return brandRepository.Read(id);
        }

        public void Create(Role obj)
        {
            if (obj.Name == "null")
            {
                throw new Exception("Name cant be empty");
            }
            brandRepository.Create(obj);
        }

        public void Delete(int id)
        {
            if (brandRepository.Read(id) != null)
            {
                brandRepository.Delete(id);
            }
            else
            {
                throw new Exception("There is no Brand with thad id");
            }
        }

        public Role MostUsedBrand()
        {
            var query = (from l in ReadAll()
                         group l by l into gr
                         orderby gr.Count() descending
                         select gr.Key).First();
            return query;
        }

        public void Update(Role obj)
        {
            if (obj != null && obj.Name != "")
            {
                brandRepository.Update(obj);
            }
            else
            {
                throw new Exception("Some Data is not valid");
            }
        }
    }
}

using NightWorks.Repository;
using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public class Address_Logic : IAddress_Logic
    {
        IAddress_Repository repo;
        public Address_Logic(IAddress_Repository repo)
        {
            this.repo = repo;
        }
        public void Create(Address item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<NWEvent> GetAllEventByAddress(int addressid)
        {
            return repo.GetAllEventByAddress(addressid);
        }

        public Address Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Address> ReadAll()
        {
            return repo.ReadAll();
        }

        public IList<Address> ReadAllByParameter(string parameter)
        {
            return repo.ReadByParameter(parameter).ToList();
        }

        public void Update(Address item)
        {
            repo.Update(item);
        }
    }
}

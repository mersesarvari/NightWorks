using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public interface IAddressLogic
    {
        Address Read(int id);
        IQueryable<Address> ReadAll();
        void Create(Address item);
        void Update(Address item);
        void Delete(int id);
        List<NWEvent> GetAllEventByAddress(int id);
    }
}

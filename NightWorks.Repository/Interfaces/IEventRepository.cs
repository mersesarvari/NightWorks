using NightWorks.Models;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IEventRepository
    {
        Event Read(int id);
        IQueryable<Event> ReadAll();
        void Create(Event item);    
        void Update(Event item);
        void Delete(int id);

        List<User> GetEventUsers(int id);
        List<Keyword> GetEventTypes(int id);
        List<Address> GetEventAddresses(int id);
        
        
    }
}

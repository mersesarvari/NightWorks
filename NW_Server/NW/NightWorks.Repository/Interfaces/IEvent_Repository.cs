using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IEvent_Repository
    {
        NWEvent Read(int id);
        IList<NWEvent> ReadAll();
        void Create(NWEvent item);    
        void Update(NWEvent item);
        void Delete(int id);
        IList<User> GetEventUsers(int id);
        IList<Keyword> GetEventTypes(int id);

        IList<NWEvent> GetEventsByUser(int id);

        IList<NWEvent> ReadAllByParameter(string parameter);


    }
}

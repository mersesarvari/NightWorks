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
        IQueryable<NWEvent> ReadAll();
        void Create(NWEvent item);    
        void Update(NWEvent item);
        void Delete(int id);



        IQueryable<NWEvent> SearchEventByCity(string parameter);
        IQueryable<NWEvent> SearchEventByCountry(string parameter);

        List<User> GetEventUsers(int id);
        List<Keyword> GetEventTypes(int id);

        IList<NWEvent> ReadAllByParameter(string parameter);
        //Connection setups
        /*
        void AddUserToEvent(User item);
        void AddKeywordToEvent(User item);
        void RemoveUserToEvent(User item);
        void RemoveKeywordToEvent(User item);
        */


    }
}

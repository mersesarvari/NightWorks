using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public interface IEvent_Logic
    {
        NWEvent Read(int id);
        IQueryable<NWEvent> ReadAll();
        void Create(NWEvent item);    
        void Update(NWEvent item);
        void Delete(int id);
        List<User> GetEventUsers(int id);
        List<Keyword> GetEventTypes(int id);

        IList<NWEvent> ReadAllByParameter(string parameter);

        //Connection setups
        void AddUserToEvent(int eventid, int userid);
        void AddKeywordToEvent(int eventid, int keywordid);
        void RemoveUserFromEvent(int id);
        void RemoveKeywordFromEvent(int id);


    }
}

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
        IList<NWEvent> ReadAll();
        void Create(NWEvent item);
        void Update(NWEvent item);
        void Delete(int id);
        IList<User> GetEventUsers(int id);
        IList<Keyword> GetEventTypes(int id);

        IList<NWEvent> ReadAllByParameter(string parameter);

        IList<NWEvent> GetEventsByUser(int id);

        //Connection setups
        void AddUserToEvent(int eventid, int userid);
        void AddKeywordToEvent(int eventid, int keywordid);
        void RemoveUserFromEvent(int id);
        void RemoveKeywordFromEvent(int eventid, int keywordid);


    }
}

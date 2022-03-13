using NightWorks.Models;
using System.Collections.Generic;

namespace NightWorks.Repository
{
    public interface ISaveEventToUser_Repository
    {
        void Create(SaveEventToUser obj);
        void Delete(int id);
        bool NotExisting(int userid, int eventid);
        SaveEventToUser Read(int id);
        IList<SaveEventToUser> ReadAll();
        SaveEventToUser ReadByData(int userid, int eventid);
        void Update(SaveEventToUser obj);
    }
}
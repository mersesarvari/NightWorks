using NightWorks.Logic;
using NightWorks.Models;
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
    public class EventLogic:IEventLogic 
    {
        IEventRepository repo;
        IEvent_KeywordConnectRepository EKrepo;
        IEvent_UserConnectRepository EUrepo;
        public EventLogic(IEventRepository repo, IEvent_KeywordConnectRepository EKrepo, IEvent_UserConnectRepository EUrepo)
        {
            this.repo = repo;
            this.EKrepo = EKrepo;
            this.EUrepo = EUrepo;
        }        

        public void Create(NWEvent item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var x = Read(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Event not found"
                );
            }
            repo.Delete(id);
        }

        public List<Address> GetEventAddresses(int id)
        {
            throw new NotImplementedException();
        }

        public List<Keyword> GetEventTypes(int id)
        {
            NWEvent x = Read(id);
            List<Keyword> types = new List<Keyword>();
            foreach (var item in x.EKeywordConns)
            {
                types.Add(item.Keyword);
            }
            return types;
        }

        public List<User> GetEventUsers(int id)
        {
            NWEvent x = Read(id);
            List<User> u = new List<User>();
            foreach (var item in x.EUserConns)
            {
                u.Add(item.User);
            }
            return u;
        }

        public NWEvent Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<NWEvent> ReadAll()
        {
            return repo.ReadAll();
        }        

        public void Update(NWEvent item)
        {
            var s = Read(item.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Event not found"
                );
            }
            s.Address_Id = item.Address_Id;
            s.EventName = item.EventName;
            s.Owner_Id = item.Owner_Id;
            s.Startingdate = item.Startingdate;
            s.Endingdate = item.Endingdate;
            s.EventText = item.EventText;
            repo.Update(s);
        }


        //TODO Have to write LOGIC
        public void AddKeywordToEvent(int eventid, int keywordid)
        {
            EKrepo.Create(new Event_Keyword_Connect() { EventId = eventid, KeywordId = keywordid });
        }

        public void AddUserToEvent(int eventid, int userid)
        {
            EUrepo.Create(new Event_User_Connect() { EventId = eventid, UserId = userid });
        }

        public void RemoveUserFromEvent(int id)
        {
            EUrepo.Delete(id);
        }

        public void RemoveKeywordFromEvent(int id)
        {
            EKrepo.Delete(id);
        }
    }
}

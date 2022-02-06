using NightWorks.Logic;
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
    public class Event_Logic:IEvent_Logic 
    {
        IEvent_Repository repo;
        IEvent_Keyword_ConnectRepository EKrepo;
        IEvent_User_Connect_Repository EUrepo;
        public Event_Logic(IEvent_Repository repo, IEvent_Keyword_ConnectRepository EKrepo, IEvent_User_Connect_Repository EUrepo)
        {
            this.repo = repo;
            this.EKrepo = EKrepo;
            this.EUrepo = EUrepo;
        }        

        public void Create(NWEvent item)
        {
            item.Creationtime = DateTime.Now;
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

        public List<Keyword> GetEventTypes(int id)
        {
            return repo.GetEventTypes(id);
        }

        public List<User> GetEventUsers(int id)
        {
            return repo.GetEventUsers(id);
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
            EKrepo.Create(new Event_Keyword_Connect() { FK_EventId = eventid, FK_KeywordId = keywordid });
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

        public IList<NWEvent> ReadAllByParameter(string parameter)
        {
            return repo.ReadAllByParameter(parameter);
        }
    }
}

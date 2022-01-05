using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public interface IEvent_UserConnectLogic
    {
        public Event_User_Connect Read(int id);
        public void Create(Event_User_Connect obj);

        public void Update(Event_User_Connect obj);

        public void Delete(int id);

        public List<Event_User_Connect> ReadAll();
    }
}

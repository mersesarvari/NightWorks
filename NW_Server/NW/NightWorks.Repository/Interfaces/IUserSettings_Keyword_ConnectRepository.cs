using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IUserSettings_Keyword_ConnectRepository
    {
        public UserSettings_Keyword_Connect Read(int id);
        public IList<UserSettings_Keyword_Connect> ReadAll();
        public void Create(UserSettings_Keyword_Connect obj);
        public void Update(UserSettings_Keyword_Connect obj);
        public void Delete(int id);        
        public UserSettings_Keyword_Connect ReadByData(int evenid, int keywordid);

        public bool NotExisting(int eventid, int keywordid);
    }
}

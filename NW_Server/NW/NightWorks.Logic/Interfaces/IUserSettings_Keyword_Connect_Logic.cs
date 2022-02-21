using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Logic
{
    public interface IUserSettings_Keyword_Connect_Logic
    {
        public UserSettings_Keyword_Connect Read(int id);
        public void Create(UserSettings_Keyword_Connect obj);

        public void Update(UserSettings_Keyword_Connect obj);

        public void Delete(int id);

        public IList<UserSettings_Keyword_Connect> ReadAll();
    }
}

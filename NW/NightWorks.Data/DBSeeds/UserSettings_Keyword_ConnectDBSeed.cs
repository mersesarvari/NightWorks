using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class UserSettings_Keyword_ConnectDBSeed
    {
        public UserSettings_Keyword_ConnectDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            UserSettings_Keyword_Connect etc1 = new UserSettings_Keyword_Connect() { Id = 1, FK_UserSettingsId = 1, FK_KeywordId = 1 };
            mb.Entity<UserSettings_Keyword_Connect>().HasData(etc1);
        }
    }
}

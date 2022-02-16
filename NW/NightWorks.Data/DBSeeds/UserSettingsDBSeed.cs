using Microsoft.EntityFrameworkCore;
using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class UserSettingsDBSeed
    {
        public UserSettingsDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            UserSettings et1 = new UserSettings() { Id = 1};
            UserSettings et2 = new UserSettings() { Id = 2};
            UserSettings et3 = new UserSettings() { Id = 3};
            mb.Entity<UserSettings>().HasData(et1,et2,et3);
        }
    }
}

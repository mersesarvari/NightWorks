using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Repository
{
    public interface IUser_Repository
    {
        void Create(User user);
        void Delete(int id);
        User Read(int id);
        IList<User> ReadAll();
        void Update(User user);
        User GetUserbyEmail(string email);


    }

}

using System;
using System.Collections.Generic;
using NigthWorks.Data;
using NigthWorks.Models;

namespace NigthWorks.Logic{
    public interface IUser_Logic
    {
        User Read(int id);
        IList<User> ReadAll();
        void Create(User obj);
        void Update(User obj);
        void Delete(int id);

        double AVGMoney();

        User MostMoneyUser();
        User LessMoneyUser();

        User Login(string email, string password);
        User GetUserByEmail(string email);
        void SaveEvent(int userid, int eventid);




    }
}

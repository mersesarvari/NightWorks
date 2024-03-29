﻿
using NigthWorks.Models;
using System.Collections.Generic;

namespace NigthWorks.Repository
{
    public interface ISaveEventToUser_Repository
    {
        void Create(SaveEventToUser obj);
        void Delete(int id);
        SaveEventToUser Read(int id);
        IList<SaveEventToUser> ReadAll();
        SaveEventToUser ReadByData(int userid, int eventid);
        void Update(SaveEventToUser obj);
        public IList<SaveEventToUser> ReadAllbyUserId(int userid);
        public void Delete(int userid, int eventid);
    }
}
﻿using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public interface IAddressRepository
    {
        Address Read(int id);
        IQueryable<Address> ReadAll();
        void Create(Address item);
        void Update(Address item);
        void Delete(int id);
        List<Event> GetAllEventByAddress(int id);
    }
}
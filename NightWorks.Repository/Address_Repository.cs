﻿using NigthWorks.Data;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Repository
{
    public class Address_Repository : IAddress_Repository
    {
        NWDbContext db;
        public Address_Repository(NWDbContext db)
        {
            this.db = db;
        }
        public void Create(Address item)
        {
            var context = new NWDbContext();
            context.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = Read(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Address with that id not found"
                );
            }
            db.Remove(x);
            db.SaveChanges();
        }

        public List<NWEvent> GetAllEventByAddress(int id)
        {
            Address x = Read(id);
            List<NWEvent> list = new List<NWEvent>();
            foreach (var item in x.Events)
            {
                list.Add(item);
            }
            return list;
        }

        public Address Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Addresses.FirstOrDefault(t => t.Id == id);
            }
        }

        public IQueryable<Address> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Addresses;
            }
        }

        public void Update(Address item)
        {
            var s = Read(item.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Address not found"
                );
            }
            s.Country = item.Country;
            s.PostalCode = item.PostalCode;
            s.City = item.City;
            s.Street = item.Street;
            s.BuildingNumber = item.BuildingNumber;
            db.SaveChanges();
        }
    }
}
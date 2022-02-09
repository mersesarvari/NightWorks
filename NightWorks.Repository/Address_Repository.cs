using NigthWorks.Data;
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


        public Address Read(int id)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Addresses.FirstOrDefault(t => t.AddressId == id);
            }
        }

        public IList<Address> ReadByParameter(string parameter)
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                if (parameter == null)
                {
                    return db.Addresses.ToList();
                }
                else {
                    var returndata = db.Addresses;
                    IList<Address> list = new List<Address>();
                    if (returndata.Where(x => x.Event.Address.FormattedAddress.ToLower().Contains(parameter.ToLower())).ToList().Count() > 0)
                    {
                        list = returndata.Where(x => x.Event.Address.FormattedAddress.ToLower().Contains(parameter.ToLower())).ToList();
                    }
                    else
                    {
                        throw new Exception("We dont find any elements");
                    }
                    return list;
                }
                
            }
        }

        public IList<Address> ReadAll()
        {
            if (db == null)
            {
                throw new Exception("There is no data in database");
            }
            else
            {
                return db.Addresses.ToList();
            }
        }

        public void Update(Address item)
        {
            var s = Read(item.AddressId);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Address not found"
                );
            }
            s.FormattedAddress = item.FormattedAddress;
            db.SaveChanges();
        }
    }
}

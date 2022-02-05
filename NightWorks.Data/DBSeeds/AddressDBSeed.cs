using Microsoft.EntityFrameworkCore;
using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class AddressDBSeed
    {
        public AddressDBSeed(ModelBuilder mb)
        {
            LoadData(mb);
        }
        public static void LoadData(ModelBuilder mb)
        {
            List<Address> addresses = new List<Address>();
            Address a1 = new Address()
            {
                Id = 1,
                Longitude = 19.0891178,
                Latitude = 47.5818847,
                City = "Budapest",
                Country = "Hungary",
                Street = "Ady Endre u.",
                BuildingNumber = 3,
                PostalCode = 1044
            };
            Address a2 = new Address()
            {
                Id = 2,
                Longitude = 20.1436765,
                Latitude = 46.25701189999999,
                City = "Szeged",
                Country = "Hungary",
                Street = "Mérey utca",
                BuildingNumber = 13,
                PostalCode = 6722
            };
            Address a3 = new Address()
            {
                Id = 3,
                Longitude = 18.229786,
                Latitude = 46.072483,
                City = "Pécs",
                Country = "Hungary",
                Street = "Bajcsy-Zsilinszky utca",
                BuildingNumber = 5,
                PostalCode = 7622
            };
            addresses.Add(a1);
            addresses.Add(a2);
            addresses.Add(a3);
            mb.Entity<Address>().HasData(addresses);
        }
    }
}
